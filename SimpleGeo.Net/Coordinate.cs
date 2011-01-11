// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Coordinate.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   Defines the Coordinate type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleGeo.Net
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Defines the Coordinate type.
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinate"/> class.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        public Coordinate(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinate"/> class using decimal degree string lat/lng values.
        /// </summary>
        /// <param name="latitude">The latitude, e.g. '38.889722'.</param>
        /// <param name="longitude">The longitude, e.g. '-77.008889'.</param>
        public Coordinate(string latitude, string longitude)
        {
            if (latitude == null)
            {
                throw new ArgumentNullException("latitude");
            }

            if (longitude == null)
            {
                throw new ArgumentNullException("longitude");
            }

            double lat;
            double lng;

            if (!double.TryParse(latitude, NumberStyles.Float, CultureInfo.InvariantCulture, out lat))
            {
                throw new ArgumentOutOfRangeException("latitude", "Latitude must be a proper lat (+/- double) value, e.g. '38.889722'.");
            }

            if (!double.TryParse(longitude, NumberStyles.Float, CultureInfo.InvariantCulture, out lng))
            {
                throw new ArgumentOutOfRangeException("longitude", "Longitude must be a proper lon (+/- double) value, e.g. '-77.008889'.");
            }

            this.Latitude = lat;
            this.Longitude = lng;
        }

        /// <summary>
        /// Gets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public double Latitude { get; private set; }

        /// <summary>
        /// Gets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public double Longitude { get; private set; }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "Latitude: {0}, Longitude: {1}", this.Latitude, this.Longitude);
        }
    }
}
