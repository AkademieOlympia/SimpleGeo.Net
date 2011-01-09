// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Polygon.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   Defines the Polygon type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleGeo.Net
{
    using System.Collections.Generic;

    /// <summary>
    /// In geography, a polygon is an area bounded by a closed path of points.
    /// Neighborhoods, state boundaries, and even buildings can be considered <seealso cref="Polygon"/>s.
    /// </summary>
    /// <seealso cref="http://simplegeo.com/docs/getting-started/simplegeo-101#polygon"/>
    public class Polygon
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Polygon"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        public Polygon(List<Point> points = null)
        {
            this.Points = points ?? new List<Point>();
        }

        /// <summary>
        /// Gets the list of points outlining this Polygon.
        /// </summary>
        public List<Point> Points { get; private set; }
    }
}
