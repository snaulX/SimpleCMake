using System;
using System.Collections.Generic;
using System.Text;

namespace CMakeUtils
{
    public class CMakeScript
    {
        public List<ICMakeFunction> functions;

        public CMakeScript()
        {
            functions = new List<ICMakeFunction>();
            CMakeProject.Scripts.Add(this);
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
