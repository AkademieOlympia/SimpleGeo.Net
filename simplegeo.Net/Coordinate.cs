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
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "Latitude: {0}, Longitude: {1}", this.Latitude, this.Longitude);
        }
    }
}
