using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace UniversityPhysics.Astrophysics
{
    [Serializable]
    public class OverLappingRadiusException: Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public OverLappingRadiusException()
        {
        }

        public OverLappingRadiusException(string message) : base(message)
        {
        }

        public OverLappingRadiusException(string message, Exception inner) : base(message, inner)
        {
        }

        protected OverLappingRadiusException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
