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
        private List<CMakeTarget> targets;

        public CMakeScript()
        {
            targets = new List<CMakeTarget>();
        }

        public void CreateTarget(string name, TargetType type)
        {
            targets.Add(new CMakeTarget(name, type));
        }

        // TODO: Make more optimizer
        /// <summary>
        /// Find target in this script with current name
        /// </summary>
        /// <exception cref="TargetNotFoundException">Throws when target not found</exception>
        public CMakeTarget FindTarget(string name)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i].name == name)
                    return targets[i];
            }
            throw new TargetNotFoundException($"Target with name {name} not found in this script");
        }
    }
}
