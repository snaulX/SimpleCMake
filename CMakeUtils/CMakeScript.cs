using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace CMakeUtils
{
    public sealed class CMakeScript
    {
        public string FileName
        {
            get => $"{folder}/CMakeLists.txt";
        }
        public List<ICMakeFunction> functions;
        public string folder;
        public bool Entrypoint { set; get; }

        private List<CMakeTarget> targets;

        public CMakeScript()
        {
            Entrypoint = false;
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
            using (StreamWriter sw = new StreamWriter(File.OpenWrite(FileName)))
            {
                sw.Write(ToString());
            }
        }

        public void ReadFile()
        {
            using (StreamReader sr = new StreamReader(File.OpenRead(FileName)))
            {
                string line = sr.ReadLine();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != '(')
                        sb.Append(line[i]);
                    else
                        break;
                }
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

        public void Build(string buildFolder)
        {
            Process buildProcess = Process.Start("cmake", "--build " + buildFolder);
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
