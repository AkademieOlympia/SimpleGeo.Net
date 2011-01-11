﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultiPolygon.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   Defines the MultiPolygon type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleGeo.Net
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the MultiPolygon type.
    /// </summary>
    public class MultiPolygon : IGeometry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiPolygon"/> class.
        /// </summary>
        /// <param name="polygons">The polygons contained in this MultiPolygon.</param>
        public MultiPolygon(List<Polygon> polygons = null)
        {
            this.Polygons = polygons ?? new List<Polygon>();
        }

        /// <summary>
        /// Gets the list of points Polygons enclosed in this MultiPolygon.
        /// </summary>
        public List<Polygon> Polygons { get; private set; }
    }
}
