using System;
using System.Runtime.Serialization;

namespace PlacetoPay.Integrations.Library.CSharp.Exceptions
{
    [Serializable]
    class PlacetoPayException : Exception, ISerializable
    {
        public PlacetoPayException(string message) : base(message)
        {
        }

        public static string ReadException(Exception e)
        {
            return e.Message + " ON " + e.Source + " " + e.TargetSite + " " + e.StackTrace;
        }
    }
}
