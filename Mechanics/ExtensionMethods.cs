using System;
using System.Collections.Generic;
using System.Text;
using UniversityPhysics.PhysicsObjects;

namespace UniversityPhysics.Mechanics
{
    public static class ExtensionMethods
    {
        public static double DistanceBetween(this PhysicsObjectBase obj, PhysicsObjectBase obj2)
        {
            return (obj.Position - obj2.Position).Abs();
        }
    }
}
