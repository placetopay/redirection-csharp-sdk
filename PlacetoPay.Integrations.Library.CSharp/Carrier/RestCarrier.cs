using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlacetoPay.Integrations.Library.CSharp.Contracts;
using PlacetoPay.Integrations.Library.CSharp.Entities;
using PlacetoPay.Integrations.Library.CSharp.Exceptions;
using PlacetoPay.Integrations.Library.CSharp.Message;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace PlacetoPay.Integrations.Library.CSharp.Carrier
{
    public class RestCarrier : Contracts.Carrier
    {
        public RestCarrier(Authentication auth, Configuration config) : base(auth, config)
        {
        }

        public override RedirectInformation Collect(CollectRequest collectRequest)
        {
            try
            {
                string endpoint = "api/collect";
                string method = "POST";
                var response = this.MakeRequest(method, endpoint, collectRequest);

                return JsonConvert.DeserializeObject<RedirectInformation>(response);
            }
            catch (Exception ex)
            {
                Status status = new Status("ERROR", "WR", PlacetoPayException.ReadException(ex), (DateTime.Now).ToString("yyyy-MM-ddTHH\\:mm\\:sszzz"));
                RedirectInformation redirectInformation = new RedirectInformation(0, status, null, null, null);

                return redirectInformation;
            }
        }

        public override RedirectResponse Request(RedirectRequest redirectRequest)
        {
            try
            {
                string endpoint = "api/session";
                string method = "POST";
                var response = this.MakeRequest(method, endpoint, redirectRequest);

                return JsonConvert.DeserializeObject<RedirectResponse>(response);
            }
            catch (Exception ex)
            {
                Status status = new Status("ERROR", "WR", PlacetoPayException.ReadException(ex), (DateTime.Now).ToString("yyyy-MM-ddTHH\\:mm\\:sszzz"));
                RedirectResponse redirectResponse = new RedirectResponse(null, null, status);

                return redirectResponse;
            }
        }

        public override RedirectInformation Query(string requestId)
        {
            JToken responseJObject = null;

            try {
                string endpoint = "api/session/" + requestId;
                string method = "POST";
                var response = this.MakeRequest(method, endpoint);
                responseJObject = JObject.Parse(response);
                JToken fields = responseJObject["request"]["fields"];
                responseJObject["request"]["fields"] = null;

                RedirectInformation information = JsonConvert.DeserializeObject<RedirectInformation>(responseJObject.ToString());

                List<NameValuePair> items = new List<NameValuePair>();
                foreach(var field in fields) {
                    NameValuePair item = JsonConvert.DeserializeObject<NameValuePair>(field.ToString(), Serializer.JsonSerializer.Settings);
                    items.Add(item);
                }

                information.Request.Fields = new Fields(items);

                return information;
            }
            catch(Exception ex)
            {
                Status status = new Status("ERROR", "WR", PlacetoPayException.ReadException(ex), (DateTime.Now).ToString("yyyy-MM-ddTHH\\:mm\\:sszzz"));

                if (responseJObject != null)
                {
                    status = new Status(responseJObject["status"]["status"].ToString() , responseJObject["status"]["reason"].ToString(), responseJObject["status"]["message"].ToString(), responseJObject["status"]["date"].ToString());
                }

                RedirectInformation redirectInformation = new RedirectInformation(0, status, null, null, null);

                return redirectInformation;
            }
        }

        public override ReverseResponse Reverse(string transactionId)
        {
            try
            {
                Object internalReference = new { internalReference = transactionId };
                string endpoint = "api/reverse";
                string method = "POST";
                var response = this.MakeRequest(method, endpoint, internalReference);

                return JsonConvert.DeserializeObject<ReverseResponse>(response);
            }
            catch (Exception ex)
            {
                Status status = new Status("ERROR", "WR", PlacetoPayException.ReadException(ex), (DateTime.Now).ToString("yyyy-MM-ddTHH\\:mm\\:sszzz"));
                ReverseResponse reverseResponse = new ReverseResponse(null, status);

                return reverseResponse;
            }
        }

        private string MakeRequest(string method, string endpoint, object arguments = null)
        {
            dynamic package = new JObject();

            if (arguments != null)
            {
                string requesst = Serializer.JsonSerializer.SerializeObject(arguments);
                JObject requestJson = JObject.Parse(requesst);
                package = requestJson;
            }

            package.auth = this.AuthRequest();

            var request = new RestRequest(endpoint, Method.POST);            
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("User-Agent", "Provider C#");
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", package.ToString(), ParameterType.RequestBody);

            var client = new RestClient(this.Config.Url) { Encoding = Encoding.UTF8 };
            IRestResponse response = client.Execute(request);

            return response.Content; // raw content as string
        }

        private dynamic AuthRequest()
        {
            dynamic auth = new JObject();
            auth.login = this.Authentication.Login;
            auth.tranKey = this.Authentication.Digest();
            auth.nonce = Utils.Base64(Encoding.ASCII.GetBytes(this.Authentication.auth.GetNonce()));
            auth.seed = this.Authentication.auth.GetSeed();

            return auth;
        }
    }
}
