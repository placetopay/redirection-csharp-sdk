using PlacetoPay.Integrations.Library.CSharp.Exceptions;

namespace PlacetoPay.Integrations.Library.CSharp.Carrier
{
    public partial class Authentication
    {
        //private const string WSU = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";
        //private const string WSSE = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";

        private string login;
        private string tranKey;
        public Auth auth;
        private bool overrided = true;
        private string type;

        public Authentication(string login, string tranKey, Auth auth = null, string type = "full")
        {
            if (login == null || tranKey == null)
                throw new PlacetoPayException("No login or tranKey provided on authentication");

            this.login = login;
            this.tranKey = tranKey;
            this.type = type;
            ValidAuth(auth);
            if (this.overrided)
                this.auth = new Auth();
        }

        private void ValidAuth(Auth auth)
        {
            if (this.auth != null)
            {
                if (auth.GetSeed() == null || auth.GetNonce() == null)
                    throw new PlacetoPayException("Bad definition for the override");

                this.auth = auth;
                this.overrided = false;
            }
        }

        public string Login {
            get { return login; }
            set { login = value; }
        }

        public string TranKey {
            get { return tranKey; }
            set { tranKey = value; }
        }

        public string Digest()
        {
            string digest = "";

            if (this.type.Equals("full"))
            {
                digest = this.auth.GetNonce() + this.auth.GetSeed() + this.tranKey;
            }
            else
            {
                digest = this.auth.GetSeed() + this.tranKey;
            }

            return Utils.Base64( Utils.Sha1(digest) );
        }
    }
}
