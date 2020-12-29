using System;
using System.Collections.Generic;
using System.Text;

namespace CMakeUtils
{
    public static class CMakeProject
    {
        public static List<CMakeTarget> Targets { private set; get; }

        public static void Init()
        {
            Targets = new List<CMakeTarget>();
        }
    }
}
