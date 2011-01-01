// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Geometry.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   Defines the Geometry type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleGeo.Net
{
    /// <summary>
    /// Represents and contains one Geometry type (<see cref="Point"/>, <see cref="Polygon"/> or <see cref="MultiPolygon"/>).
    /// </summary>
    public class Geometry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Geometry"/> class.
        /// </summary>
        /// <param name="point">The point.</param>
        public Geometry(Point point)
        {
            this.Point = point;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Geometry"/> class.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        public Geometry(Polygon polygon)
        {
            this.Polygon = polygon;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Geometry"/> class.
        /// </summary>
        /// <param name="multiPolygon">The multi polygon.</param>
        public Geometry(MultiPolygon multiPolygon)
        {
            this.MultiPolygon = multiPolygon;
        }

        /// <summary>
        /// Gets or sets the point.
        /// </summary>
        /// <value>The point.</value>
        public Point Point { get; set; }

        /// <summary>
        /// Gets or sets the polygon.
        /// </summary>
        /// <value>The polygon.</value>
        public Polygon Polygon { get; set; }

        /// <summary>
        /// Gets or sets the multi polygon.
        /// </summary>
        /// <value>The multi polygon.</value>
        public MultiPolygon MultiPolygon { get; set; }
    }
}
