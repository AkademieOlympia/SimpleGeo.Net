// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FeatureCategory.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   Defines the FeatureCategory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleGeo.Net
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the FeatureCategory type. See <see cref="http://simplegeo.com/docs/api-endpoints/simplegeo-features#list-feature-categories"/> for further details
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FeatureCategory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureCategory"/> class.
        /// </summary>
        public FeatureCategory()
        {
            this.Category = string.Empty;
            this.Type = string.Empty;
            this.Subcategory = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureCategory"/> class.
        /// </summary>
        /// <seealso cref="http://simplegeo.com/docs/api-endpoints/simplegeo-features#list-feature-categories"/>
        /// <param name="category">The category.</param>
        /// <param name="type">The type of the category.</param>
        /// <param name="subcategory">The subcategory.</param>
        internal FeatureCategory(string category, string type, string subcategory = "")
        {
            if (category == null)
            {
                throw new ArgumentNullException("category");
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentOutOfRangeException("category", "Must not be empty");
            }

            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentOutOfRangeException("type", "Must not be empty");
            }

            this.Category = category;
            this.Type = type;
            this.Subcategory = subcategory ?? string.Empty;
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        [JsonProperty(PropertyName = "category", Required = Required.Always)]
        public string Category { get; private set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type { get; private set; }

        /// <summary>
        /// Gets the sub category.
        /// </summary>
        [JsonProperty(PropertyName = "subcategory")]
        public string Subcategory { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is a Main Category or not.
        /// </summary>
        internal bool IsMainCategory
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.Subcategory);
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.IsMainCategory
                ? string.Format("'{0}' / '{1}'", this.Category, this.Type)
                : string.Format("'{0}' ('{1}' / '{2}')", this.Subcategory, this.Category, this.Type);
        }
    }
}
