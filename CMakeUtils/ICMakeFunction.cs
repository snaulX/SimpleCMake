using System;
using System.Collections.Generic;
using System.Text;

namespace CMakeUtils
{
    public interface ICMakeFunction
    {
        public string ToCMakeLine();
        /// <summary>
        /// Get name of function for CMake syntax
        /// </summary>
        /// <returns></returns>
        public string GetName();
        public void SetArgs(List<string> args);
    }
}
