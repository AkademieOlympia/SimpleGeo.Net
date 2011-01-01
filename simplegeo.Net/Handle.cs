// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Handle.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   Defines the Handle type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleGeo.Net
{
    using System;
    using System.Text;

    /// <summary>
    /// A SimpleGeo handle uniquely identifies a <see cref="Feature"/>
    /// </summary>
    /// <seealso cref="http://simplegeo.com/docs/getting-started/simplegeo-101#handle"/>
    public class Handle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Handle"/> class.
        /// </summary>
        /// <param name="uniqueString">The unique string.</param>
        /// <param name="approximateLocation">The approximate location.</param>
        /// <param name="epoch">The epoch which will be converted to Unix Timestamp internally.</param>
        internal Handle(string uniqueString, Coordinate approximateLocation = null, DateTime? epoch = null)
        {
            if (uniqueString == null)
            {
                throw new ArgumentNullException("uniqueString");
            }

            if (string.IsNullOrWhiteSpace(uniqueString))
            {
                throw new ArgumentOutOfRangeException("uniqueString", "Must contain an unique string");
            }

            this.UniqueString = uniqueString;

            if (approximateLocation != null)
            {
                this.ApproximateLocation = approximateLocation;
            }

            if (epoch != null)
            {
                this.Epoch = epoch.GetValueOrDefault();
            }
        }

        /// <summary>
        /// Gets the unique string.
        /// </summary>
        /// <value>The unique string.</value>
        public string UniqueString { get; private set; }

        /// <summary>
        /// Gets the approximate location.
        /// </summary>
        /// <value>The approximate location.</value>
        public Coordinate ApproximateLocation { get; private set; }

        /// <summary>
        /// Gets the epoch.
        /// </summary>
        /// <value>The epoch.</value>
        public DateTime? Epoch { get; private set; }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance in compliance with <see cref="http://simplegeo.com/docs/getting-started/simplegeo-101#handle"/>.
        /// </returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("SG");
            stringBuilder.Append("_");
            stringBuilder.Append(this.UniqueString);

            if (this.ApproximateLocation != null)
            {
                stringBuilder.Append(this.ApproximateLocation.Latitude);
                stringBuilder.Append("_");
                stringBuilder.Append(this.ApproximateLocation.Longitude);
            }

            if (this.Epoch != null)
            {
                stringBuilder.Append("_");
                stringBuilder.Append(Math.Floor((this.Epoch.GetValueOrDefault() - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds));
            }

            return stringBuilder.ToString();
        }
    }
}
