using System;
using System.Collections.Generic;
using System.Text;

namespace CMakeUtils
{
    public static class CMakeProject
    {
        public static List<CMakeTarget> Targets { private set; get; }
        public static List<CMakeScript> Scripts { private set; get; }

        public static void Init()
        {
            Targets = new List<CMakeTarget>();
            Scripts = new List<CMakeScript>();
        }

        /// <summary>
        /// Find target with getted name
        /// </summary>
        /// <exception cref="TargetNotFoundException">Throws when target not found</exception>
        public static CMakeTarget FindTarget(string name)
        {
            for (int i = 0; i < Targets.Count; i++)
            {
                if (Targets[i].name == name)
                    return Targets[i];
            }
            throw new TargetNotFoundException(name);
        }
    }

    public class TargetNotFoundException : Exception
    {
        public TargetNotFoundException() : base() { }
        public TargetNotFoundException(string message) : base(message) { }
    }
}
