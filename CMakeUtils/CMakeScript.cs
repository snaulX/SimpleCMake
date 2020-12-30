using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CMakeUtils
{
    public sealed class CMakeScript
    {
        public List<ICMakeFunction> functions;
        public string folder;

        private List<CMakeTarget> targets;

        public CMakeScript()
        {
            targets = new List<CMakeTarget>();
            folder = "";
            functions = new List<ICMakeFunction>();
            CMakeProject.Scripts.Add(this);
        }

        public void AddTarget(CMakeTarget target)
        {
            targets.Add(target);
        }

        public void WriteFile()
        {
            using (StreamWriter sw = new StreamWriter(File.OpenWrite($"{folder}/CMakeLists.txt")))
            {
                sw.Write(ToString());
            }
        }

        public CMakeTarget FindTarget(string name)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i].name == name)
                    return targets[i];
            }
            return null;
        }

        public override string ToString()
        {
            StringBuilder script = new StringBuilder();
            for (int i = 0; i < functions.Count; i++)
            {
                script.AppendLine(functions[i].ToCMakeLine());
            }
            return script.ToString();
        }
    }
}
