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
    using Hammock.Authentication.OAuth;

    /// <summary>
    /// The Client Class is the main entry point to send requests to and get responses from the SimpleGeo Api
    /// </summary>
    public sealed class Client : Hammock.RestClient
    {
        /// <summary>
        /// Defines the (as of writing) base API Url and endpoint for the SimpleGeo Api
        /// </summary>
        private const string AUTHORITY = "http://api.simplegeo.com";

        /// <summary>
        /// Defines the (as of writing) API version for the SimpleGeo Api
        /// </summary>
        private const string VERSIONPATH = "1.0";

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="oauthKey">The OAuth key.</param>
        /// <param name="oauthSecret">The OAuth secret.</param>
        /// <param name="authority">The base API URL (default 'http://api.simplegeo.com').</param>
        /// <param name="versionPath">The API version (default '1.0').</param>
        public Client(
            string oauthKey,
            string oauthSecret,
            string authority = AUTHORITY,
            string versionPath = VERSIONPATH)
            : this(
                new OAuthCredentials
                    {
                        Type = OAuthType.RequestToken,
                        SignatureMethod = OAuthSignatureMethod.HmacSha1,
                        ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
                        ConsumerKey = oauthKey,
                        ConsumerSecret = oauthSecret
                    },
                authority,
                versionPath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="oauthCredentials">The oauth credentials.</param>
        /// <param name="authority">The base API URL (default 'http://api.simplegeo.com'). This will be used in the complete API URL using '{authority}/{versionPath}/'.</param>
        /// <param name="versionPath">The API version (default '1.0'). This will be used in the complete API URL using '{authority}/{versionPath}/'.</param>
        public Client(
            OAuthCredentials oauthCredentials,
            string authority = "http://api.simplegeo.com",
            string versionPath = "1.0") : this()
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

            if (string.IsNullOrWhiteSpace(authority))
            {
                throw new ArgumentOutOfRangeException("authority", "A working base url for the SimpleGeo API must be provided (e.g. 'http://api.simplegeo.com')");
            }

            if (string.IsNullOrWhiteSpace(versionPath))
            {
                throw new ArgumentOutOfRangeException("versionPath", "A proper API version string the SimpleGeo API must be provided (e.g. '1.0', see 'http://help.simplegeo.com/entries/209077-what-versions-of-the-api-are-available')");
            }

            Authority = authority;
            VersionPath = versionPath;

            Credentials = oauthCredentials;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        internal Client()
            : base()
        {
        }
    }
}
