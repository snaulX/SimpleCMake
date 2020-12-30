using System;
using System.Collections.Generic;
using System.Text;

namespace CMakeUtils
{
    public static class CMakeProject
    {
        public static List<CMakeScript> Scripts { private set; get; }

        public static void Init()
        {
            Scripts = new List<CMakeScript>();
        }

        /// <summary>
        /// Find target with getted name
        /// </summary>
        /// <exception cref="TargetNotFoundException">Throws when target not found</exception>
        public static CMakeTarget FindTarget(string name)
        {
            for (int i = 0; i < Scripts.Count; i++)
            {
                CMakeTarget t = Scripts[i].FindTarget(name);
                if (t != null)
                    return t;
            }
            throw new TargetNotFoundException(name);
        }

        public static void Compile()
        {
            for (int i = 0; i < Scripts.Count; i++)
            {
                Scripts[i].WriteFile();
            }
        }
    }

    public class TargetNotFoundException : Exception
    {
        public TargetNotFoundException() : base() { }
        public TargetNotFoundException(string message) : base(message) { }
    }
}
