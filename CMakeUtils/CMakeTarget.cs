using System;
using System.Collections.Generic;
using System.Text;

namespace CMakeUtils
{
    public enum TargetType
    {
        Executable,
        StaticLibrary,
        DynamicLybrary
    }

    public class CMakeTarget
    {
        public List<string> sources, headers, dir_headers;
        public string name;
        public TargetType type;

        public CMakeTarget()
        {
            sources = new List<string>();
            headers = new List<string>();
            dir_headers = new List<string>();
            name = "";
            type = TargetType.Executable;
        }

        public CMakeTarget(string name, TargetType type) : this()
        {
            this.name = name;
            this.type = type;
        }
    }
}
