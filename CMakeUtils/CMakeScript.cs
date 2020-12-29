using System;
using System.Collections.Generic;

namespace CMakeUtils
{
    public class TargetNotFoundException : Exception
    {
        public TargetNotFoundException() : base() { }
        public TargetNotFoundException(string message) : base(message) { }
    }

    public class CMakeScript
    {
        public List<ICMakeFunction> functions;

        public CMakeScript()
        {
            functions = new List<ICMakeFunction>();
        }
    }
}
