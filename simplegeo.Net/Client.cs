// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Client.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   The Client Class is the main entry point to send requests to and get responses from the SimpleGeo Api
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleGeo.Net
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization.Formatters;
    using System.Threading.Tasks;

    using Hammock;
    using Hammock.Authentication.OAuth;

    using Newtonsoft.Json;

    /// <summary>
    /// The Client Class is the main entry point to send requests to and get responses from the SimpleGeo Api
    /// This Class derives from <see cref="Hammock.RestClient"/> allowing direct access to the underlying raw
    /// methods and properties.
    /// </summary>
    public sealed class Client : RestClient
    {
        /// <summary>
        /// Defines the (as of writing) base API Url and endpoint for the SimpleGeo Api
        /// </summary>
        internal const string AUTHORITY = "http://api.simplegeo.com";

        /// <summary>
        /// Defines the (as of writing) API version for the SimpleGeo Api
        /// </summary>
        internal const string VERSIONPATH = "1.0";

        /// <summary>
        /// Locking object used for thread-safety of underlying hammock client
        /// </summary>
        private static readonly object clientLocker = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="oauthKey">The OAuth key.</param>
        /// <param name="oauthSecret">The OAuth secret.</param>
        public Client(
            string oauthKey,
            string oauthSecret)
            : this(
                new OAuthCredentials
                    {
                        Type = OAuthType.RequestToken,
                        SignatureMethod = OAuthSignatureMethod.HmacSha1,
                        ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
                        ConsumerKey = oauthKey,
                        ConsumerSecret = oauthSecret
                    })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="oauthCredentials">The oauth credentials.</param>
        public Client(
            OAuthCredentials oauthCredentials) : this()
        {
            if (oauthCredentials == null)
            {
                throw new ArgumentNullException("oauthCredentials");
            }

            if (string.IsNullOrWhiteSpace(oauthCredentials.ConsumerKey))
            {
                throw new ArgumentOutOfRangeException("oauthCredentials", "ConsumerKey must not be empty");
            }

            if (string.IsNullOrWhiteSpace(oauthCredentials.ConsumerSecret))
            {
                throw new ArgumentOutOfRangeException("oauthCredentials", "ConsumerSecret must not be empty");
            }

            Authority = AUTHORITY;
            VersionPath = VERSIONPATH;

            Credentials = oauthCredentials;
            
            UserAgent = "simplegeo.Net Client Application";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        internal Client()
        {
        }

        /// <summary>
        /// Gets the feature by its <c>Handle</c>.
        /// </summary>
        /// <param name="handle">The <see cref="Handle"/>.</param>
        /// <returns>The requested <c>Feature</c> if found, otherwise <c>null</c>.</returns>
        public Feature GetFeature(Handle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException("handle");
            }

            var request = this.GetFeatureRequest(handle);

            string responseContent;

            lock (clientLocker)
            {
                responseContent = Request(request).Content;
            }

            return JsonConvert.DeserializeObject<Feature>(
                responseContent,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple });
        }

        /// <summary>
        /// Gets the feature by its complete handle, e.g. 'SG_2MySaPILVQG3MoXrsVehyR_37.215297_-119.663837' (see http://simplegeo.com/docs/getting-started/simplegeo-101#feature for handle format)
        /// </summary>
        /// <param name="handle">The <see cref="Handle"/> but in proper string format.</param>
        /// <returns>The requested <c>Feature</c> if found, otherwise <c>null</c>.</returns>
        public Feature GetFeature(string handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException("handle");
            }

            if (string.IsNullOrWhiteSpace(handle))
            {
                throw new ArgumentOutOfRangeException("handle", "Handle may not be empty.");
            }

            return this.GetFeature(Handle.Parse(handle));
        }

        /// <summary>
        /// Gets the feature by its <c>Handle</c>.
        /// </summary>
        /// <param name="handle">The <see cref="Handle"/>.</param>
        /// <returns>A running TPL Task which you can use and read its result from the .Result property</returns>
        public Task<Feature> GetFeatureAsync(Handle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException("handle");
            }

            return Task.Factory.StartNew(() => this.GetFeature(handle));
        }

        /// <summary>
        /// Gets the feature by its complete handle, e.g. 'SG_2MySaPILVQG3MoXrsVehyR_37.215297_-119.663837' (see http://simplegeo.com/docs/getting-started/simplegeo-101#feature for handle format)
        /// </summary>
        /// <param name="handle">The <see cref="Handle"/> but in proper string format.</param>
        /// <returns>A running TPL Task which you can use and read its result from the .Result property</returns>
        public Task<Feature> GetFeatureAsync(string handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException("handle");
            }

            if (string.IsNullOrWhiteSpace(handle))
            {
                throw new ArgumentOutOfRangeException("handle", "Handle may not be empty.");
            }

            return Task.Factory.StartNew(() => this.GetFeature(handle));
        }

        /// <summary>
        /// Gets the feature request.
        /// </summary>
        /// <param name="handle">The SimpleGeo feature handle.</param>
        /// <returns>A <c>RestRequest</c> prepared for Feature fetching but which you can either manipulate further or e.g. use in raw Async calls</returns>
        public RestRequest GetFeatureRequest(Handle handle)
        {
            return new RestRequest
            {
                Path = string.Format("features/{0}.json", handle)
            };
        }

        /// <summary>
        /// Gets the feature categories.
        /// </summary>
        /// <returns>A list of the available Feature Categories (see http://simplegeo.com/docs/api-endpoints/simplegeo-features#list-feature-categories)</returns>
        public List<FeatureCategory> GetFeatureCategories()
        {
            var request = this.GetFeatureCategoriesRequest();

            string responseContent;

            lock (clientLocker)
            {
                responseContent = Request(request).Content;
            }

            return JsonConvert.DeserializeObject<List<FeatureCategory>>(responseContent);
        }

        /// <summary>
        /// Gets the feature categories request.
        /// </summary>
        /// <returns>A <c>RestRequest</c> prepared for FeatureCategories fetching but which you can either manipulate further or e.g. use in raw Async calls</returns>
        public RestRequest GetFeatureCategoriesRequest()
        {
            return new RestRequest
            {
                Path = "features/categories.json"
            };
        }

        /// <summary>
        /// Gets the feature categories asyncronously.
        /// </summary>
        /// <returns>A running TPL Task which you can use and read its result from the .Result property</returns>
        public Task<List<FeatureCategory>> GetFeatureCategoriesAsync()
        {
            return Task.Factory.StartNew<List<FeatureCategory>>(this.GetFeatureCategories);
        }
    }
}
