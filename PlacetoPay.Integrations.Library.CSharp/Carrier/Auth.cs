using System;

namespace PlacetoPay.Integrations.Library.CSharp.Carrier
{
    public partial class Authentication
    {
        public class Auth
        {
            private string seed;
            private string nonce;

            public Auth()
            {
                this.SetSeed();
                this.SetNonce();
            }

            public Auth(string seed, string nonce)
            {
                this.seed = seed;
                this.nonce = nonce;
            }

            public string GetSeed()
            {
                return this.seed;
            }

            public void SetSeed(string value = null)
            {
                this.seed = value;

                if (this.seed == null)
                    this.seed = (DateTime.Now).ToString("yyyy-MM-ddTHH\\:mm\\:sszzz");
            }

            public string GetNonce()
            {
                return this.nonce;
            }

            public void SetNonce(string value = null)
            {
                this.nonce = value;

                if (this.nonce == null)
                {
                    byte[] array = new byte[8];
                    Random random = new Random();
                    random.NextBytes(array);
                    this.nonce = System.Text.Encoding.ASCII.GetString(array);
                }
            }
            
        }

    }
}
