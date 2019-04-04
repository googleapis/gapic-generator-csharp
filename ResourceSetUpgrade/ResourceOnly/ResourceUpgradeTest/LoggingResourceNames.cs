// Copyright 2019 Google LLC
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

// Generated code. DO NOT EDIT!

using gax = Google.Api.Gax;
using sys = System;

namespace ResourceUpgradeTest
{
    /// <summary>Resource name for the <c>Log</c> resource</summary>
    public sealed partial class LogName : gax::IResourceName, sys::IEquatable<LogName>
    {
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("projects/{project}/logs/{log}");

        /// <summary>
        /// Parses the given <c>Log</c> resource name in string form into a new <see cref="LogName"/> instance.
        /// </summary>
        /// <param name="log">The <c>Log</c> resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="LogName"/> if successful.</returns>
        public static LogName Parse(string log)
        {
            gax::GaxPreconditions.CheckNotNull(log, nameof(log));
            gax::TemplatedResourceName resourceName = s_template.ParseName(log);
            return new LogName(resourceName[0], resourceName[1]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new <see cref="LogName"/> instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="log"/> is <c>null</c>,
        /// as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="log">The <c>Log</c> resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="LogName"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string log, out LogName result)
        {
            gax::GaxPreconditions.CheckNotNull(log, nameof(log));
            if (s_template.TryParseName(log, out gax::TemplatedResourceName resourceName))
            {
                result = new LogName(resourceName[0], resourceName[1]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// Constructs a new instance of the <see cref="LogName"/> resource name class from its component parts.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c>.</param>
        /// <param name="logId">The <c>Log</c> ID. Must not be <c>null</c>.</param>
        public LogName(string projectId, string logId)
        {
            ProjectId = gax::GaxPreconditions.CheckNotNull(projectId, nameof(projectId));
            LogId = gax::GaxPreconditions.CheckNotNull(logId, nameof(logId));
        }

        /// <summary>The <c>Project</c> ID. Never <c>null</c>.</summary>
        public string ProjectId { get; }

        /// <summary>The <c>Log</c> ID. Never <c>null</c>.</summary>
        public string LogId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(ProjectId, LogId);

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as LogName);

        /// <inheritdoc/>
        public bool Equals(LogName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(LogName a, LogName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(LogName a, LogName b) => !(a == b);
    }

    /// <summary>Resource name for the <c>Project</c> resource</summary>
    public sealed partial class ProjectName : gax::IResourceName, sys::IEquatable<ProjectName>
    {
        private static readonly gax::PathTemplate s_template = new gax::PathTemplate("projects/{project}");

        /// <summary>
        /// Parses the given <c>Project</c> resource name in string form into a new <see cref="ProjectName"/> instance.
        /// </summary>
        /// <param name="project">The <c>Project</c> resource name in string form. Must not be <c>null</c>.</param>
        /// <returns>The parsed <see cref="ProjectName"/> if successful.</returns>
        public static ProjectName Parse(string project)
        {
            gax::GaxPreconditions.CheckNotNull(project, nameof(project));
            gax::TemplatedResourceName resourceName = s_template.ParseName(project);
            return new ProjectName(resourceName[0]);
        }

        /// <summary>
        /// Tries to parse the given session resource name in string form into a new <see cref="ProjectName"/> instance.
        /// </summary>
        /// <remarks>
        /// This method still throws <see cref="sys::ArgumentNullException"/> if <paramref name="project"/> is <c>null</c>
        /// , as this would usually indicate a programming error rather than a data error.
        /// </remarks>
        /// <param name="project">The <c>Project</c> resource name in string form. Must not be <c>null</c>.</param>
        /// <param name="result">
        /// When this method returns, the parsed <see cref="ProjectName"/>, or <c>null</c> if parsing fails.
        /// </param>
        /// <returns><c>true</c> if the name was parsed successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string project, out ProjectName result)
        {
            gax::GaxPreconditions.CheckNotNull(project, nameof(project));
            if (s_template.TryParseName(project, out gax::TemplatedResourceName resourceName))
            {
                result = new ProjectName(resourceName[0]);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// Constructs a new instance of the <see cref="ProjectName"/> resource name class from its component parts.
        /// </summary>
        /// <param name="projectId">The <c>Project</c> ID. Must not be <c>null</c>.</param>
        public ProjectName(string projectId) => ProjectId = gax::GaxPreconditions.CheckNotNull(projectId, nameof(projectId));

        /// <summary>The <c>Project</c> ID. Never <c>null</c>.</summary>
        public string ProjectId { get; }

        /// <inheritdoc/>
        public gax::ResourceNameKind Kind => gax::ResourceNameKind.Simple;

        /// <inheritdoc/>
        public override string ToString() => s_template.Expand(ProjectId);

        /// <inheritdoc/>
        public override int GetHashCode() => ToString().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as ProjectName);

        /// <inheritdoc/>
        public bool Equals(ProjectName other) => ToString() == other?.ToString();

        /// <inheritdoc/>
        public static bool operator ==(ProjectName a, ProjectName b) => ReferenceEquals(a, b) || (a?.Equals(b) ?? false);

        /// <inheritdoc/>
        public static bool operator !=(ProjectName a, ProjectName b) => !(a == b);
    }

    public partial class DeleteLogRequest
    {
        /// <summary><see cref="LogName"/>-typed view over the <see cref="LogName"/> resource name property.</summary>
        public LogName LogNameAsLogName
        {
            get => string.IsNullOrEmpty(LogName) ? null : LogName.Parse(LogName);
            set => LogName = value?.ToString() ?? "";
        }
    }

    public partial class ListLogsRequest
    {
        /// <summary>
        /// <see cref="ProjectName"/>-typed view over the <see cref="Parent"/> resource name property.
        /// </summary>
        public ProjectName ParentAsProjectName
        {
            get => string.IsNullOrEmpty(Parent) ? null : ProjectName.Parse(Parent);
            set => Parent = value?.ToString() ?? "";
        }
    }
}
