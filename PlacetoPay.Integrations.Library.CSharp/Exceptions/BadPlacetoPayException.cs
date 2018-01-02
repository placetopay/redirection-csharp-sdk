using System;
using System.Runtime.Serialization;

namespace PlacetoPay.Integrations.Library.CSharp.Exceptions
{
    [Serializable]
    class BadPlacetoPayException : Exception, ISerializable
    {
        public BadPlacetoPayException(string msg) : base(msg)
        { }
    }
}
