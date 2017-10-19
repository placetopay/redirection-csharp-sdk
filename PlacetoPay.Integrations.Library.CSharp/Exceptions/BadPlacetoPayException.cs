using System;

namespace PlacetoPay.Integrations.Library.CSharp.Exceptions
{
    class BadPlacetoPayException : Exception
    {
        public BadPlacetoPayException(string msg) : base(msg)
        { }
    }
}
