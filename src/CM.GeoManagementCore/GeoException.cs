﻿using System;
using System.Runtime.Serialization;

namespace CM.GeoManagementCore
{
    [Serializable]
    public class GeoException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public GeoException()
        {
        }

        public GeoException(string message) : base(message)
        {
        }

        public GeoException(string message, Exception inner) : base(message, inner)
        {
        }

        protected GeoException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}