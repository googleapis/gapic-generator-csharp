// Copyright 2020 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;

namespace Google.Api.Generator.ProtoUtils
{
    internal class ResourcePattern
    {
        public abstract class Segment
        {
            public abstract IReadOnlyList<string> ParameterNames { get; }
            public abstract IReadOnlyList<char> Separators { get; }

            /// <summary>
            /// A segment string suitable for using in Gax::PathTemplate.
            /// </summary>
            public abstract string PathTemplateString { get; }

            /// <summary>
            /// A string that can be used to construct a regular expression matching this segment.
            /// </summary>
            public abstract string RegexString { get; }
            public abstract string Expand(IEnumerable<string> parameters);
            public int ParameterCount => ParameterNames.Count;
            public bool IsComplex => Separators.Count > 0;
        }

        private class CollectionIdentifierSegment : Segment
        {
            public CollectionIdentifierSegment(string segment)
            {
                Identifier = segment;
                Validate(tightValidation: false);
            }

            public void Validate(bool tightValidation)
            {
                var s = Identifier;
                // Loose validation is required to support pubsub's legacy use of the pattern '_deleted-topic_'
                bool valid = tightValidation ?
                    s != "" && s[0] >= 'a' && s[0] <= 'z' && s.All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9')) :
                    s != "" && s.All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || c == '-' || c == '_');
                if (!valid)
                {
                    throw new ArgumentException($"Segment '{s}' is ill-formed; contains invalid characters.");
                }
            }

            public string Identifier { get; }
            public override IReadOnlyList<string> ParameterNames => ImmutableList<string>.Empty;
            public override IReadOnlyList<char> Separators => ImmutableList<char>.Empty;
            public override string PathTemplateString => Identifier;
            public override string RegexString => Identifier;
            public override string Expand(IEnumerable<string> parameters) => Identifier;
            public override string ToString() => Identifier;
        }

        private class WildcardSegment: Segment
        {
            public WildcardSegment(string segment)
            {
                if (segment != "*" && segment != "**")
                {
                    throw new ArgumentException(
                        $"Segment {segment} is invalid. Wildcard segments are only allowed to be '*' or '**'.");
                }

                Pattern = segment;
            }
            public string Pattern { get; }
            public override IReadOnlyList<string> ParameterNames => ImmutableList<string>.Empty;
            public override IReadOnlyList<char> Separators => ImmutableList<char>.Empty;
            public override string PathTemplateString => Pattern;
            public override string RegexString => Pattern == "**" ? DoubleWildcardStandaloneRegexStr : SingleWildcardRegexStr;

            /// <summary>
            /// NB: [virost, 2021/12] The expanding is currently limited to the patterns with named parameters.
            /// If the usages of expanding expand to include the wildcard parameters, this can be implemented accordingly.
            /// </summary>
            public override string Expand(IEnumerable<string> parameters) =>
                throw new InvalidOperationException("Expanding is not supported for the wildcard segments because it is not currently required.");
            public override string ToString() => Pattern;
        }

        private class MultivariateResourceIdSegment : Segment
        {
            public MultivariateResourceIdSegment(string segment)
            {
                var separators = new List<char>();
                var parameterNames = new List<string>();
                var parameterNamesWithSuffix = new List<string>();
                int pos = 0;
                while (true)
                {
                    Check(segment[pos] == '{', $"'{{' expected at position {pos}.");
                    int closePos = segment.IndexOf('}', pos + 1);
                    Check(closePos >= 0, "missing '}}'.");
                    var p = segment[(pos + 1)..closePos];
                    Check(p != "", "empty parameter name.");
                    parameterNamesWithSuffix.Add(p);
                    if (p.EndsWith("=**"))
                    {
                        p = p[..^3];
                    }
                    else if (p.EndsWith("=*"))
                    {
                        p = p[..^2];
                    }
                    bool valid = p[0] >= 'a' && p[0] <= 'z' && p.All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || c == '_');
                    Check(valid, $"parameter name '{p}' contains invalid characters.");
                    parameterNames.Add(p);
                    if (closePos == segment.Length - 1)
                    {
                        break;
                    }
                    Check(segment.Length >= closePos + 3, "unexpected end of segment.");
                    char sep = segment[closePos + 1];
                    Check(sep == '_' || sep == '-' || sep == '.' || sep == '~', $"invalid separator character '{sep}'.");
                    separators.Add(sep);
                    pos = closePos + 2;
                }
                if (parameterNames.Count > 1)
                {
                    Check(parameterNamesWithSuffix.All(p => !p.EndsWith("=**")), "'=**' suffix not valid in a multi-ID segment.");
                }
                Separators = separators;
                ParameterNames = parameterNames;
                ParameterNamesWithSuffix = parameterNamesWithSuffix;

                void Check(bool cond, string msg)
                {
                    if (!cond)
                    {
                        throw new ArgumentException($"Segment '{segment}' is ill-formed; {msg}");
                    }
                }
            }

            public override IReadOnlyList<char> Separators { get; }
            public override IReadOnlyList<string> ParameterNames { get; }
            private IReadOnlyList<string> ParameterNamesWithSuffix { get; }
            public override string PathTemplateString => $"{{{(ParameterCount == 1 ? ParameterNamesWithSuffix[0] : string.Join('_', ParameterNames))}}}";
            public override string RegexString => 
                throw new NotImplementedException("Forming a regex string of a multivariate resource id segment is not implemented.");
            public override string Expand(IEnumerable<string> parameters) =>
                parameters.First() + string.Join("", Separators.Zip(parameters.Skip(1), (s, p) => $"{s}{p}"));
            public override string ToString() =>
                string.Join("", ParameterNamesWithSuffix.Zip(Separators, (p, s) => $"{{{p}}}{s}").Append($"{{{ParameterNamesWithSuffix[^1]}}}"));
        }

        private class ResourceIdSegment : Segment
        {
            public ResourceIdSegment(string segment)
            {
                Check(segment.First() == '{', $"'{{' expected at the beginning of the segment `{segment}`.");
                Check(segment.IndexOf('}') != -1, $"missing '}}' in the segment `{segment}`.");
                Check( segment.IndexOf('}') == segment.LastIndexOf('}'), $"extra '}}' in the segment `{segment}`.");
                Check(segment.Last() == '}', $"'}}' expected to be at the end of the segment `{segment}`.");
                _givenSegment = segment;

                var indexOfEquals = segment.IndexOf('=');
                Check(indexOfEquals == segment.LastIndexOf('='), $"extra `=` in the segment `{segment}`." );
                
                string paramName = indexOfEquals == -1 
                    ? segment.Substring(1, segment.Length-2)
                    : segment.Substring(1, indexOfEquals-1);

                bool valid = Regex.IsMatch(paramName, "^[a-zA-Z][a-zA-Z0-9_.]*$");
                Check(valid, $"parameter name '{paramName}' contains invalid characters.");
                _parameterName = paramName;

                _givenPattern = indexOfEquals == -1
                    ? string.Empty
                    : segment.Substring(indexOfEquals + 1, segment.Length - indexOfEquals - 2);

                // A ResourceId segment `{name}` is equivalent to `{name=*}`
                string effectiveParamPatternStr = _givenPattern == String.Empty
                    ? "*"
                    : _givenPattern;

                _effectivePattern = new ResourcePattern(effectiveParamPatternStr);
                
                void Check(bool cond, string msg)
                {
                    if (!cond)
                    {
                        throw new ArgumentException($"Segment '{segment}' is ill-formed; {msg}");
                    }
                }
            }

            private readonly string _givenSegment;
            private readonly string _parameterName;
            private readonly string _givenPattern;
            private readonly ResourcePattern _effectivePattern;

            public string Pattern => _givenPattern;
            public override IReadOnlyList<char> Separators => ImmutableList<char>.Empty;
            public override IReadOnlyList<string> ParameterNames => new List<string> { _parameterName };
            public override string PathTemplateString => _givenSegment;
            public override string RegexString => $"({_effectivePattern.RegexString})";
            public override string Expand(IEnumerable<string> parameters) =>
                parameters.First() + string.Join("", Separators.Zip(parameters.Skip(1), (s, p) => $"{s}{p}"));
            public override string ToString() => PathTemplateString;

            internal bool EndsWithDoubleWildcardPattern => _effectivePattern.EndsWithDoubleWildcardPattern;
        }

        // When double wildcard is by itself it can be anything
        public const string DoubleWildcardStandaloneRegexStr = ".*";
        // When double wildcard has a segment before it, it's either nothing or slash-separated anything
        public const string DoubleWildcardInPatternRegexStr = "(?:/.*)?";
        public const string SingleWildcardRegexStr = "[^/]+";
        
        
        public ResourcePattern(string pattern)
        {
            string remainder = Regex.Replace(pattern, "^/", string.Empty);
            
            if (string.IsNullOrWhiteSpace(remainder))
            {
                throw new ArgumentException($"Pattern '{pattern}' contains only leading slash and/or whitespace.");
            }

            var segments = new List<Segment>();
            while (remainder != string.Empty)
            {
                var (segment, position) = CaptureNextSegmentWithPosition(remainder);
                segments.Add(segment);
                remainder = remainder.Substring(position);
            }

            Segments = segments.ToImmutableList();
            if (Segments.OfType<ResourceIdSegment>().Any())
            {
                // Perform tight (standard) validation if there are any resource-id path-segments in this pattern.
                // Loose validation is required to support pubsub's legacy use of the pattern '_deleted-topic_'
                foreach (var segment in Segments.OfType<CollectionIdentifierSegment>())
                {
                    segment.Validate(tightValidation: true);
                }
            }
        }

        private (Segment, int) CaptureNextSegmentWithPosition(string pattern)
        {
            var wildcardRegex = new Regex(@"^(?<pattern>\*\*|\*)(?:/|$)");
            if (wildcardRegex.Match(pattern) is { Success: true } wildMatch)
            {
                return (new WildcardSegment(wildMatch.Groups["pattern"].Value),
                    wildMatch.Value.Length);
            }

            var multiVariateRegex =
                new Regex(@"^(?<pattern>{(?<name_first>[^\/}\=]+?)(?:\=\*)?}(?:(?<separator>[_\-~.]){(?<name_seq>[^\/}\=]+?)(?:\=\*)?})+)(?:\/|$)");
            if (multiVariateRegex.Match(pattern) is { Success: true } multiMatch)
            {
                return (new MultivariateResourceIdSegment(multiMatch.Groups["pattern"].Value),
                    multiMatch.Length);
            }

            var resourceIdRegex =
                new Regex(@"^(?<pattern>{(?<resource_name>[^\/}\=]+?)(?:=(?<resource_pattern>[^}]+?))?})(?:\/|$)");
            if (resourceIdRegex.Match(pattern) is { Success: true } resourceMatch)
            {
                return (new ResourceIdSegment(resourceMatch.Groups["pattern"].Value),
                    resourceMatch.Length);
            }

            var collectionIdRegex = new Regex(@"^(?<pattern>[^/]+?)(?:/|$)");
            if (collectionIdRegex.Match(pattern) is { Success: true } collectionMatch)
            {
                return (new CollectionIdentifierSegment(collectionMatch.Groups["pattern"].Value),
                    collectionMatch.Length);
            }

            throw new ArgumentException($"Sub-pattern '{pattern}' does not match any known segment types.");
        }

        private ResourcePattern(IEnumerable<Segment> segments) => Segments = segments.ToImmutableList();

        public IReadOnlyList<Segment> Segments { get; }

        public IEnumerable<string> ParameterNames => Segments.SelectMany(x => x.ParameterNames);

        public string Expand(IReadOnlyList<string> parameters) => string.Join('/',
            Segments.Aggregate((result: ImmutableList<string>.Empty, paramOfs: 0),
                (acc, seg) => (acc.result.Add(seg.Expand(parameters.Skip(acc.paramOfs))), acc.paramOfs + seg.ParameterCount),
                acc => acc.result));

        public string PathTemplateString => string.Join('/', Segments.Select(x => x.PathTemplateString));

        public string RegexString
        {
            get
            {
                var regexStr = Segments.First().RegexString;
                // for double wildcards the leading `/`` is optional
                // e.g. `foo/**` should match `foo`
                // this is why we can't simply join segments' regex strings

                return Segments.Skip(1)
                    .Aggregate(regexStr, (current, segment) => segment switch
                    {
                        WildcardSegment { Pattern: "**" } => $"{current}{DoubleWildcardInPatternRegexStr}",
                        ResourceIdSegment { Pattern: "**" } seg => $"{current}{ConvertStandaloneWildcardSegmentRegexStr(seg.RegexString)}",
                        _ => $"{current}/{segment.RegexString}"
                    });

                // Converts `(<name>.*)` to `(<name>/.*)?`
                string ConvertStandaloneWildcardSegmentRegexStr(string standalone)
                {
                    return $"{standalone.Replace(".", "/.")}?";
                }
            }
        }

        /// <summary>
        /// If the pattern is effectively a double wildcard, regex-matching it can be skipped
        /// </summary>
        public bool IsDoubleWildcardPattern => Segments.Count == 1 && Segments.Single() switch
        {
            WildcardSegment  { Pattern: "**" } wcdId => true,
            ResourceIdSegment { Pattern: "**" } resId => true,
            _ => false
        };

        /// <summary>
        /// The double-wildcard pattern on the end of the expression
        /// takes care of a possible trailing slash
        /// </summary>
        public string FullFieldRegexString =>
            EndsWithDoubleWildcardPattern
                ? $"^{RegexString}$"
                : $"^{RegexString}/?$";

        /// <summary>
        /// If the pattern end with a double wildcard, its regex does not need to be updated
        /// to match an optional `/` at the end
        /// </summary>
        private bool EndsWithDoubleWildcardPattern => Segments.Last() switch
        {
            WildcardSegment { Pattern: "**" } wcdId => true,
            ResourceIdSegment resId => resId.EndsWithDoubleWildcardPattern,
            _ => false
        };

        /// <summary>
        /// Construct the string used in comparisons when determining resource-name parent(s).
        /// Parent comparisons are on the pattern with all resource-ID segments removed.
        /// Therefore the following match: users/{user} and users/{user_a}-{user_b}
        /// The following do not match: users/{user} and users/{user_a}/{user_b}
        /// </summary>
        public string ParentComparisonString => string.Join('/', Segments.Select(seg => seg switch
        {
            CollectionIdentifierSegment colId => colId.Identifier,
            WildcardSegment wcdId => "",
            ResourceIdSegment resId => "",
            MultivariateResourceIdSegment mvResId => "",
            _ => throw new InvalidOperationException("Unexpected segment type.")
        }));

        public ResourcePattern Parent()
        {
            var result = Segments[^1] switch
            {
                CollectionIdentifierSegment colId => new ResourcePattern(Segments.SkipLast(1)),
                WildcardSegment wcdId => new ResourcePattern(Segments.SkipLast(2)),
                ResourceIdSegment resId => new ResourcePattern(Segments.SkipLast(2)),
                MultivariateResourceIdSegment mvResId => new ResourcePattern(Segments.SkipLast(2)),
                _ => throw new InvalidOperationException("Unexpected segment type."),
            };
            if (result.Segments.Count == 0)
            {
                throw new InvalidOperationException($"Pattern '{PathTemplateString}' has no parent.");
            }
            return result;
        }

        public override string ToString() => string.Join("/", Segments.Select(x => x.ToString()));
    }
}
