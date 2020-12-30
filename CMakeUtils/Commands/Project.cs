using System;
using System.Collections.Generic;
using System.Text;

namespace CMakeUtils.Commands
{
    public class Project : ICMakeFunction
    {
        public const string cmakeVersionText = "CMAKE_MINIMUM_VERSION_REQUIRED";

        public Project()
        {
            ProjectName = "";
            CMakeVersionMinimumRequired = new Version();
        }

        public Project(string projName) : this()
        {
            ProjectName = projName;
            //CMakeProject.Targets.Add(new CMakeTarget(projName));
        }

        public Project(string projName, string cMakeVersion) : this(projName)
        {
            try
            {
                CMakeVersionMinimumRequired = Version.Parse(cMakeVersion);
            }
            catch
            {
                Console.WriteLine("Version is not valid"); // TODO
            }
        }

        public string ProjectName { set; get; }
        public Version CMakeVersionMinimumRequired { set; get; }

        public string GetName() => "project";

        public void SetArgs(List<string> args)
        {
            if (args.Count == 1)
                ProjectName = args[0];
            if (args.Count == 3)
            {
                if (args[1] == cmakeVersionText)
                    CMakeVersionMinimumRequired = Version.Parse(args[2]);
            }
        }

        public string ToCMakeLine()
        {
            StringBuilder line = new StringBuilder();
            line.Append(GetName());
            line.Append('(');
            line.Append(ProjectName);
            if (CMakeVersionMinimumRequired.Major != 0)
            {
                line.Append(" " + cmakeVersionText + " ");
                line.Append(CMakeVersionMinimumRequired);
            }
            line.Append(')');
            return line.ToString();
        }
    }
}
