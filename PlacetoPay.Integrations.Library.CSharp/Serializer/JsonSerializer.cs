using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PlacetoPay.Integrations.Library.CSharp.Serializer
{
    public class JsonSerializer
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new LowercaseContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        public static string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented, Settings);
        }

        public class LowercaseContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return Char.ToLowerInvariant(propertyName[0]) + propertyName.Substring(1);
            }
        }
    }
}
