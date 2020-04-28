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

namespace Google.Api.Generator.Utils
{
    internal class ResourcePattern
    {
        public abstract class Segment
        {
            public static Segment Create(string segment) =>
                segment.Contains('{') ? (Segment)new ResourceIdSegment(segment) : new CollectionIdentifierSegment(segment);

            public abstract IReadOnlyList<string> ParameterNames { get; }
            public abstract IReadOnlyList<string> ParameterNamesWithSuffix { get; }
            public abstract IReadOnlyList<char> Separators { get; }
            public abstract string PathTemplateString { get; }
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
            public override IReadOnlyList<string> ParameterNamesWithSuffix => ImmutableList<string>.Empty;
            public override IReadOnlyList<char> Separators => ImmutableList<char>.Empty;
            public override string PathTemplateString => Identifier;
            public override string Expand(IEnumerable<string> parameters) => Identifier;

            public override string ToString() => Identifier;
        }

        private class ResourceIdSegment : Segment
        {
            public ResourceIdSegment(string segment)
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

            // Separators are between parameter-names; there is always one less separator than parameter-names.
            public override IReadOnlyList<char> Separators { get; }
            public override IReadOnlyList<string> ParameterNames { get; }
            public override IReadOnlyList<string> ParameterNamesWithSuffix { get; }
            /// <summary>
            /// Construct a segment suitable for using in Gax::PathTemplate.
            /// If this segment has exactly one segment, then it's returned as-is; otherwise the parameter-names are concatenated and suffixes removed.
            /// </summary>
            public override string PathTemplateString => $"{{{(ParameterCount == 1 ? ParameterNamesWithSuffix[0] : string.Join('_', ParameterNames))}}}";
            public override string Expand(IEnumerable<string> parameters) =>
                parameters.First() + string.Join("", Separators.Zip(parameters.Skip(1), (s, p) => $"{s}{p}"));

            public override string ToString() =>
                string.Join("", ParameterNamesWithSuffix.Zip(Separators, (p, s) => $"{{{p}}}{s}").Append($"{{{ParameterNamesWithSuffix[^1]}}}"));
        }

        public ResourcePattern(string pattern)
        {
            Segments = pattern.Split('/').Select(Segment.Create).ToImmutableList();
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

        private ResourcePattern(IEnumerable<Segment> segments) => Segments = segments.ToImmutableList();

        public IReadOnlyList<Segment> Segments { get; }

        public IEnumerable<string> ParameterNames => Segments.SelectMany(x => x.ParameterNames);

        public string Expand(IReadOnlyList<string> parameters) => string.Join('/',
            Segments.Aggregate((result: ImmutableList<string>.Empty, paramOfs: 0),
                (acc, seg) => (acc.result.Add(seg.Expand(parameters.Skip(acc.paramOfs))), acc.paramOfs + seg.ParameterCount),
                acc => acc.result));

        public string PathTemplateString => string.Join('/', Segments.Select(x => x.PathTemplateString));

        /// <summary>
        /// Construct the string used in comparisons when determining resource-name parent(s).
        /// Parent comparisons are on the pattern with all resource-ID segments removed.
        /// Therefore the following match: users/{user} and users/{user_a}-{user_b}
        /// The following do not match: users/{user} and users/{user_a}/{user_b}
        /// </summary>
        public string ParentComparisonString => string.Join('/', Segments.Select(seg => seg switch
        {
            CollectionIdentifierSegment colId => colId.Identifier,
            ResourceIdSegment resId => "",
            _ => throw new InvalidOperationException("Unexpected segment type.")
        }));

        public ResourcePattern Parent()
        {
            var result = Segments[^1] switch
            {
                ResourceIdSegment resId => new ResourcePattern(Segments.SkipLast(2)),
                CollectionIdentifierSegment colId => new ResourcePattern(Segments.SkipLast(1)),
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
