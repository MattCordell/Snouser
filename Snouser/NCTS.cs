using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net;

namespace NCTS
{
    public class NCTSToken
    {
        public string token_type { get; set; }
        public string scope { get; set; }
        public string expires_in { get; set; }
        public string ext_expires_in { get; set; }
        public string expires_on { get; set; }
        public string not_before { get; set; }
        public string resource { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        //returns a single string with token type and value
        public string token { get { return token_type + " " + access_token; } }
    }

    class NCTSAuthentication
    {
        private string clientId;
        private string clientSecret;
        private string NCTSEndpoint = "https://www.healthterminologies.gov.au/api";
        private string authenticationResource = "/controller/oauth2/token";

        public NCTSAuthentication(string id, string secret)
        {
            clientId = id;
            clientSecret = secret;
        }

        //This method handles everything. Users just uses the returned value in header authentication
        public string FetchTokenValue()
        {
            //specify security protocol, else gets nowhere.
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            RestClient client = new RestClient(NCTSEndpoint);
            RestRequest request = new RestRequest(authenticationResource, Method.POST);

            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("application/x-www-form-urlencoded", "client_id="+ clientId + "&client_secret="+ clientSecret + "&grant_type=client_credentials", ParameterType.RequestBody);

            var response = client.Execute(request);
            var token = SimpleJson.DeserializeObject<NCTSToken>(response.Content);

            return token.token;
        }


    }
}
