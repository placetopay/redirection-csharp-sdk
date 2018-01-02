using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlacetoPay.Integrations.Library.CSharp.Contracts;
using PlacetoPay.Integrations.Library.CSharp.Entities;
using PlacetoPay.Integrations.Library.CSharp.Exceptions;
using PlacetoPay.Integrations.Library.CSharp.Message;
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
                var response = this.MakeRequest("POST", this.Url("api/collect"), collectRequest);

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
                var response = this.MakeRequest("POST", this.Url("api/session"), redirectRequest);

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
                var response = this.MakeRequest("POST", this.Url("api/session/" + requestId));
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
                var response = this.MakeRequest("POST", this.Url("api/reverse"), internalReference);

                return JsonConvert.DeserializeObject<ReverseResponse>(response);
            }
            catch (Exception ex)
            {
                Status status = new Status("ERROR", "WR", PlacetoPayException.ReadException(ex), (DateTime.Now).ToString("yyyy-MM-ddTHH\\:mm\\:sszzz"));
                ReverseResponse reverseResponse = new ReverseResponse(null, status);

                return reverseResponse;
            }
        }

        private string MakeRequest(string method, Uri url, object arguments = null)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Provider C#");
            dynamic package = new JObject();
            package.auth = this.AuthRequest();

            if (arguments != null)
            {
                string request = Serializer.JsonSerializer.SerializeObject(arguments);
                JObject requestJson = JObject.Parse(request);
                package = requestJson;
                package.auth = this.AuthRequest();
            }

            HttpContent content = new StringContent(package.ToString(), Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, new StringContent(package.ToString(), Encoding.UTF8, "application/json")).Result;

            var contents = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            return contents.ToString();
        }

        private dynamic AuthRequest()
        {
            dynamic auth = new JObject();
            auth.login = this.Authentication.Login;
            auth.tranKey = this.Authentication.Digest();
            auth.nonce = Utils.Base64(Encoding.ASCII.GetBytes(this.Authentication.auth.GetNonce()));
            auth.seed = this.Authentication.auth.GetSeed();
            auth.fields = "additional";

            return auth;
        }

        private Uri Url(string endPoint)
        {
            return new Uri(this.Config.Url + endPoint);
        }
    }
}
