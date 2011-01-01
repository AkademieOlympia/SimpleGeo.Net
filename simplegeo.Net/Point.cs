// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Point.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   Defines the Point type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleGeo.Net
{
    using System;

    /// <summary>
    /// In geography, a point refers to a coordinate on a map, often expressed in latitude and longitude.
    /// </summary>
    /// <example>
    /// For example, the point 37° 46' 21.7776", -122° 24' 20.4366" refers to SimpleGeo's San Francisco office.
    /// </example>
    /// <seealso cref="http://simplegeo.com/docs/getting-started/simplegeo-101#point"/>
    public class Point
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        /// <param name="coordinate">The coordinate.</param>
        public Point(Coordinate coordinate)
        {
            if (coordinate == null)
            {
                throw new ArgumentNullException("coordinate");
            }

            this.Coordinate = coordinate;
        }

        /// <summary>
        /// Gets the coordinate.
        /// </summary>
        /// <value>The coordinate.</value>
        public Coordinate Coordinate { get; private set; }

        /// <summary>
        /// Gets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public double Latitude
        {
            get
            {
                return Coordinate.Latitude;
            }
        }

        /// <summary>
        /// Gets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public double Longitude
        {
            get
            {
                return Coordinate.Longitude;
            }
        }
    }
}
