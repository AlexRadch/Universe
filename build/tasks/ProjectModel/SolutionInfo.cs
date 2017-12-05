// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;

namespace RepoTasks.ProjectModel
{
    internal class SolutionInfo
    {
        public SolutionInfo(string fullPath, string configName, IReadOnlyList<ProjectInfo> projects, bool shouldBuild)
        {
            if (string.IsNullOrEmpty(fullPath))
            {
                throw new ArgumentException(nameof(fullPath));
            }

            if (string.IsNullOrEmpty(configName))
            {
                throw new ArgumentException(nameof(configName));
            }

            Directory = Path.GetDirectoryName(fullPath);
            FullPath = fullPath;
            ConfigName = configName;
            Projects = projects ?? throw new ArgumentNullException(nameof(projects));
            ShouldBuild = shouldBuild;

            foreach (var proj in Projects)
            {
                proj.SolutionInfo = this;
            }
        }

        public string Directory { get; }
        public string FullPath { get; }
        public string ConfigName { get; }
        public IReadOnlyList<ProjectInfo> Projects { get; }
        public bool ShouldBuild { get; }
    }
}
