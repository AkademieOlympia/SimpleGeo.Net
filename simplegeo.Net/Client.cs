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
    /// <summary>
    /// The Client Class is the main entry point to send requests to and get responses from the SimpleGeo Api
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Stores the OAuth Consumer Key
        /// </summary>
        private readonly string _oauthKey;

        /// <summary>
        /// Stores the OAuth Consumer Secret
        /// </summary>
        private readonly string _oauthSecret;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="oauthKey">The OAuth key.</param>
        /// <param name="oauthSecret">The OAuth secret.</param>
        public Client(string oauthKey, string oauthSecret)
        {
            this._oauthKey = oauthKey;
            this._oauthSecret = oauthSecret;
        }
    }
}
