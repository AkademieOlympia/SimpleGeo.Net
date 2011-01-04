// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Feature.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   Defines the Feature type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleGeo.Net
{
    using System.Collections.Generic;

    /// <summary>
    /// The Features endpoint provides details for all SimpleGeo features.
    /// </summary>
    /// <seealso cref="http://simplegeo.com/docs/getting-started/simplegeo-101#feature"/>
    /// <seealso cref="http://simplegeo.com/docs/api-endpoints/simplegeo-features"/>
    /// <seealso cref="http://developers.simplegeo.com/blog/2010/12/08/simplegeo-features-api/"/>
    public class Feature
    {
        /// <summary>
        /// Gets the <see cref="Handle"/>.
        /// </summary>
        /// <value>The handle.</value>
        public Handle Handle { get; private set; }

        /// <summary>
        /// Gets the geometry.
        /// </summary>
        /// <value>The geometry.</value>
        public Geometry Geometry { get; private set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type of this feature.</value>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <value>The properties.</value>
        public Dictionary<string, object> Properties { get; private set; }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns>Full Url of this Feature</returns>
        public string GetUrl(Client client)
        {
            return string.Format("{0}/{1}/features/{2}.json", client.Authority, client.VersionPath, this.Handle);
        }
    }
}
