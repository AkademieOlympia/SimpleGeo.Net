using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGeo.Net.SampleApp
{
    using Hammock;
    using Hammock.Authentication.OAuth;
    
    class Program
    {
        static void Main(string[] args)
        {
            var def = Handle.Parse("SG_2AziTafTLNReeHpRRkfipn_37.766713_-122.428938@1291796505");

            Console.WriteLine(def.ToString());

            var abc = new SimpleGeo.Net.Client("", "");
            
            string consumerKey = "<enter here>";
            string consumerSecret = "<enter here>";
            
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
