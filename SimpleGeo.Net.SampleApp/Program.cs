using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGeo.Net.SampleApp
{
    using Hammock;
    using Hammock.Authentication.OAuth;
    using Newtonsoft.Json;
    using SimpleGeo.Net.Helpers;
    using SimpleGeo.Net;
    
    class Program
    {

        static void Main(string[] args)
        {
            //var def = Handle.Parse("SG_2AziTafTLNReeHpRRkfipn_37.766713_-122.428938@1291796505");

            //Console.WriteLine(def.ToString());

            string consumerKey = "a6CZNXGZtn32GyyCbkMynZEbFGDhJSUm";
            string consumerSecret = "e5xEHjtC9vwM248yYNucZs8vFwTm2Qqf";

            var abc = new SimpleGeo.Net.Client(consumerKey, consumerSecret);

            var hmm = abc.GetContext(38.31956371178672, -85.76507091522217);
            var idk = JsonConvert.DeserializeObject<Dictionary<string, object>>(hmm.Content);

            var skldjfdf = "sldkf";

            //var baseUrl = "http://api.simplegeo.com";
            //var apiVersion = "1.0";           
            //var apiUrl = string.Format("{0}/{1}/", baseUrl, apiVersion);
            //var userAgent = "simplegeo.Net Client Library";

            //var credentials = new OAuthCredentials
            //{
            //    Type = OAuthType.RequestToken,
            //    SignatureMethod = OAuthSignatureMethod.HmacSha1,
            //    ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
            //    ConsumerKey = consumerKey,
            //    ConsumerSecret = consumerSecret,
            //};

            //var client = new RestClient
            //{
            //    Authority = apiUrl,
            //    Credentials = credentials,
            //};

            //var request = new RestRequest { Path = "context/address.json" };
            //request.AddParameter("address", "San Francisco, CA");

            //var response = client.Request(request);

            //Console.Write(response);
        }
    }
}
