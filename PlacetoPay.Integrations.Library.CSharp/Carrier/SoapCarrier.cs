using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlacetoPay.Integrations.Library.CSharp.Contracts;
using PlacetoPay.Integrations.Library.CSharp.Entities;
using PlacetoPay.Integrations.Library.CSharp.Exceptions;
using PlacetoPay.Integrations.Library.CSharp.Message;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace PlacetoPay.Integrations.Library.CSharp.Carrier
{
    public class SoapCarrier : Contracts.Carrier
    {
        private static XNamespace env = "http://www.w3.org/2003/05/soap-envelope";
        private static XNamespace wsse = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
        private static XNamespace wssu = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";
        private static XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
        private static XNamespace p2p = "http://placetopay.com/soap/redirect/";

        private Dictionary<string, string> soapAuth = new Dictionary<string, string>();
        private string _action = "";

        public SoapCarrier(Authentication auth, Configuration config) : base(auth, config)
        {
            this.SoapAuth();
        }

        public override RedirectInformation Collect(CollectRequest collectRequest)
        {
            try
            {
                this._action = "/collect";

                string request = Serializer.JsonSerializer.SerializeObject(collectRequest);

                var node = JsonConvert.DeserializeXmlNode(request, "payload");

                XElement collect = new XElement(p2p + "collect", XElement.Parse(node.OuterXml));

                string response = this.CallWebService(collect);

                response = Regex.Replace(response, @"(\s*)""@(.*)"":", @"$1""$2"":", RegexOptions.IgnoreCase);
                JObject res = JObject.Parse(response);

                if (res["ns1:collectResponse"]["collectResult"]["payment"] != null)
                {
                    var transaction = res["ns1:collectResponse"]["collectResult"]["payment"]["transaction"];
                    res["ns1:collectResponse"]["collectResult"]["payment"] = null;
                    var data = res["ns1:collectResponse"]["collectResult"];
                    RedirectInformationSOAP redirectInformationSOAP = JsonConvert.DeserializeObject<RedirectInformationSOAP>(data.ToString(), Serializer.JsonSerializer.Settings);
                    
                    if (transaction.Type.ToString() == "Object")
                    {
                        List<TransactionSOAP> transactions = new List<TransactionSOAP>();
                        TransactionSOAP transactionSOAP = JsonConvert.DeserializeObject<TransactionSOAP>(transaction.ToString());
                        transactions.Add(transactionSOAP);
                        redirectInformationSOAP.Payment = transactions;
                    }
                    else
                    {
                        List<TransactionSOAP> transactions = new List<TransactionSOAP>();
                        TransactionSOAP transactionSOAP;
                        foreach (var item in transaction.Children())
                        {
                            transactionSOAP = JsonConvert.DeserializeObject<TransactionSOAP>(item.ToString());
                            transactions.Add(transactionSOAP);
                        }
                        redirectInformationSOAP.Payment = transactions;
                    }
                    
                    List<Transaction> paymentTransaction = new List<Transaction>();
                    foreach (var tSOAP in redirectInformationSOAP.Payment)
                    {
                        Transaction T = new Transaction(tSOAP.Status, tSOAP.Reference, tSOAP.InternalReference, tSOAP.PaymentMethod, tSOAP.PaymentMethodName, tSOAP.IssuerName, tSOAP.Amount, tSOAP.Authorization, tSOAP.Receipt, tSOAP.Franchise, tSOAP.Refunded, tSOAP.ProcessorFields.item);
                        paymentTransaction.Add(T);
                    }

                    RedirectInformation redirectInformation = new RedirectInformation(redirectInformationSOAP.RequestId, redirectInformationSOAP.Status, redirectInformationSOAP.Request, paymentTransaction, null);

                    return redirectInformation;
                }
                else if (res["ns1:collectResponse"]["collectResult"]["subscription"] != null)
                {
                    var data = res["ns1:getRequestInformationResponse"]["getRequestInformationResult"];
                    RedirectInformationSOAP redirectInformationSOAP = JsonConvert.DeserializeObject<RedirectInformationSOAP>(data.ToString());
                    SubscriptionInfomationSOAP subscriptionInfomationSOAP = redirectInformationSOAP.Subscription;
                    SubscriptionInformation subscriptionInformation = new SubscriptionInformation(subscriptionInfomationSOAP.Type, subscriptionInfomationSOAP.Status, subscriptionInfomationSOAP.Instrument.item);
                    RedirectInformation redirectInformation = new RedirectInformation(redirectInformationSOAP.RequestId, redirectInformationSOAP.Status, redirectInformationSOAP.Request, null, subscriptionInformation);

                    return redirectInformation;
                }
                else
                {
                    var data = res["ns1:collectResponse"]["collectResult"];
                    return JsonConvert.DeserializeObject<RedirectInformation>(data.ToString());
                }

            }
            catch (Exception ex)
            {
                Status status = new Status("ERROR", "WR", PlacetoPayException.ReadException(ex), (DateTime.Now).ToString("yyyy-MM-ddTHH\\:mm\\:sszzz"));
                RedirectInformation redirectInformation = new RedirectInformation(0, status, null, null, null);

                return redirectInformation;
            }
            
        }

        public override RedirectInformation Query(string requestId)
        {
            try
            {
                this._action = "/getRequestInformation";

                var package = new XElement("requestId",
                    requestId
                );

                XElement request = new XElement(p2p + "getRequestInformation", package);

                string response = this.CallWebService(request);
                response = Regex.Replace(response, @"(\s*)""@(.*)"":", @"$1""$2"":", RegexOptions.IgnoreCase);
                JObject res = JObject.Parse(response);


                if (res["ns1:getRequestInformationResponse"]["getRequestInformationResult"]["payment"] != null)
                {
                    var transaction = res["ns1:getRequestInformationResponse"]["getRequestInformationResult"]["payment"]["transaction"];

                    res["ns1:getRequestInformationResponse"]["getRequestInformationResult"]["payment"] = null;
                    var data = res["ns1:getRequestInformationResponse"]["getRequestInformationResult"];
                    RedirectInformationSOAP redirectInformationSOAP = JsonConvert.DeserializeObject<RedirectInformationSOAP>(data.ToString(), Serializer.JsonSerializer.Settings);

                    if (transaction.Type.ToString() == "Object")
                    {
                        List<TransactionSOAP> transactions = new List<TransactionSOAP>();
                        TransactionSOAP transactionSOAP = JsonConvert.DeserializeObject<TransactionSOAP>(transaction.ToString());
                        transactions.Add(transactionSOAP);
                        redirectInformationSOAP.Payment = transactions;
                    }
                    else
                    {
                        List<TransactionSOAP> transactions = new List<TransactionSOAP>();
                        TransactionSOAP transactionSOAP;
                        foreach (var item in transaction.Children())
                        {
                            transactionSOAP = JsonConvert.DeserializeObject<TransactionSOAP>(item.ToString());
                            transactions.Add(transactionSOAP);
                        }

                        redirectInformationSOAP.Payment = transactions;
                    }

                    List<Transaction> paymentTransaction = new List<Transaction>();
                    foreach (var tSOAP in redirectInformationSOAP.Payment)
                    {
                        List<NameValuePair> processorFields = tSOAP.ProcessorFields != null ? tSOAP.ProcessorFields.item : null;
                        Transaction T = new Transaction(tSOAP.Status, tSOAP.Reference, tSOAP.InternalReference, tSOAP.PaymentMethod, tSOAP.PaymentMethodName, tSOAP.IssuerName, tSOAP.Amount, tSOAP.Authorization, tSOAP.Receipt, tSOAP.Franchise, tSOAP.Refunded, processorFields);
                        paymentTransaction.Add(T);
                    }

                    RedirectInformation redirectInformation = new RedirectInformation(redirectInformationSOAP.RequestId, redirectInformationSOAP.Status, redirectInformationSOAP.Request, paymentTransaction, null);

                    return redirectInformation;
                }
                else if (res["ns1:getRequestInformationResponse"]["getRequestInformationResult"]["subscription"] != null)
                {
                    var data = res["ns1:getRequestInformationResponse"]["getRequestInformationResult"];
                    RedirectInformationSOAP redirectInformationSOAP = JsonConvert.DeserializeObject<RedirectInformationSOAP>(data.ToString());
                    SubscriptionInfomationSOAP subscriptionInfomationSOAP = redirectInformationSOAP.Subscription;
                    SubscriptionInformation subscriptionInformation = new SubscriptionInformation(subscriptionInfomationSOAP.Type, subscriptionInfomationSOAP.Status, subscriptionInfomationSOAP.Instrument.item);
                    RedirectInformation redirectInformation = new RedirectInformation(redirectInformationSOAP.RequestId, redirectInformationSOAP.Status, redirectInformationSOAP.Request, null, subscriptionInformation);

                    return redirectInformation;
                }
                else
                {
                    var data = res["ns1:getRequestInformationResponse"]["getRequestInformationResult"];
                    return JsonConvert.DeserializeObject<RedirectInformation>(data.ToString());
                }
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
                this._action = "/createRequest";

                string request = Serializer.JsonSerializer.SerializeObject(redirectRequest);

                var node = JsonConvert.DeserializeXmlNode(request, "payload");

                XElement createRequest = new XElement(p2p + "createRequest", XElement.Parse(node.OuterXml));

                string response = this.CallWebService(createRequest);

                JObject res = JObject.Parse(response);
                var data = res["ns1:createRequestResponse"]["createRequestResult"];

                return JsonConvert.DeserializeObject<RedirectResponse>(data.ToString());
            }
            catch (Exception ex)
            {
                Status status = new Status("ERROR", "WR", PlacetoPayException.ReadException(ex), (DateTime.Now).ToString("yyyy-MM-ddTHH\\:mm\\:sszzz"));
                RedirectResponse redirectResponse = new RedirectResponse(null, null, status);

                return redirectResponse;
            }
        }

        public override ReverseResponse Reverse(string transactionId)
        {
            try
            {
                this._action = "/reversePayment";

                var package = new XElement("internalReference",
                    transactionId
                );

                XElement reverse = new XElement(p2p + "reversePayment", package);

                string response = this.CallWebService(reverse);

                JObject res = JObject.Parse(response);
                var data = res["ns1:reversePaymentResponse"]["reversePaymentResult"];

                return JsonConvert.DeserializeObject<ReverseResponse>(data.ToString());
            }
            catch (Exception ex)
            {
                Status status = new Status("ERROR", "WR", PlacetoPayException.ReadException(ex), (DateTime.Now).ToString("yyyy-MM-ddTHH\\:mm\\:sszzz"));
                ReverseResponse reverseResponse = new ReverseResponse(null, status);

                return reverseResponse;
            }
        }


        public string CallWebService(XElement createRequest)
        {
            XElement body = this.SoapBody(createRequest);
            XmlDocument soapEnvelopeXml = CreateSoapEnvelope(body);
            HttpWebRequest webRequest = CreateWebRequest();
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;

            string responseText = string.Empty;

            WebResponse webResponse = webRequest.EndGetResponse(asyncResult);
            StreamReader rd = new StreamReader(webResponse.GetResponseStream());
            string response = rd.ReadToEnd();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);
            doc = Utils.RemoveNullFields(doc);
            soapResult = JsonConvert.SerializeXmlNode(doc);
            JObject res = JObject.Parse(soapResult);
            var envelope = res["env:Envelope"]["env:Body"];
            soapResult = envelope.ToString();

            return soapResult;
        }

        private HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(this.Config.Location);
            webRequest.Headers.Add("SOAPAction", this.Config.Location + this._action);
            webRequest.UserAgent = "Provider C#";
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private XmlDocument CreateSoapEnvelope(XElement body)
        {
            XElement element = new XElement(env + "Envelope",
                new XAttribute(XNamespace.Xmlns + "env", env),
                new XAttribute(XNamespace.Xmlns + "wsse", wsse),
                new XAttribute(XNamespace.Xmlns + "wssu", wssu),
                new XAttribute(XNamespace.Xmlns + "xsi", xsi),
                new XAttribute(XNamespace.Xmlns + "p2p", p2p),
                this.SoapHeader(),
                body
            );
            
            XmlDocument soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(element.ToString());
            
            return soapEnvelop;
        }

        private XElement SoapHeader()
        {
            return new XElement(env + "Header",
                    new XElement(wsse + "Security",
                        new XAttribute(env + "mustUnderstand", "true"),
                        new XElement(wsse + "UsernameToken",
                            new XElement(wsse + "Username", this.soapAuth["login"]),
                            new XElement(wsse + "Password", this.soapAuth["trankey"],
                                new XAttribute(xsi + "type", "PasswordDigest")
                            ),
                            new XElement(wsse + "Nonce", this.soapAuth["nonce"]),
                            new XElement(wsse + "Created", this.soapAuth["seed"])
                        )
                    )
            );
        }

        private XElement SoapBody(XElement request)
        {
            return new XElement(env + "Body",
               request
           );
        }

        private void SoapAuth()
        {
            this.soapAuth.Add("login", this.Authentication.Login);
            this.soapAuth.Add("trankey", this.Authentication.Digest());
            this.soapAuth.Add("nonce", Utils.Base64(Encoding.ASCII.GetBytes(this.Authentication.auth.GetNonce())));
            this.soapAuth.Add("seed", this.Authentication.auth.GetSeed());
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
