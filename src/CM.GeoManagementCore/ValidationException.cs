﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CM.GeoManagementCore
{
    [Serializable]
    public class ValidationException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ValidationException()
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ValidationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
