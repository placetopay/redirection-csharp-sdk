using System;

namespace PlacetoPay.Integrations.Library.CSharp.Exceptions
{
    class PlacetoPayException : Exception
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
