﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointConverter.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   Defines the PolygonConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleGeo.Net.Helpers.Json.Converters
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using SimpleGeo.Net.Exceptions;

    /// <summary>
    /// Converter to read and write the <see cref="MultiPolygon" /> type.
    /// </summary>
    public class PointConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param><param name="value">The value.</param><param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param><param name="objectType">Type of the object.</param><param name="existingValue">The existing value of object being read.</param><param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var coordinates = serializer.Deserialize<JArray>(reader);
            if (coordinates == null || coordinates.Count != 2)
            {
                throw new ParsingException(
                    string.Format(
                        "Point geometry coordinates could not be parsed. Expected something like '[-122.428938,37.766713]' ([lon,lat]), what we received however was: {0}", 
                        coordinates));
            }

            string latitude;
            string longitude;
            try
            {
                longitude = coordinates.First.ToString();
                latitude = coordinates.Last.ToString();
            }
            catch (Exception ex)
            {
                throw new ParsingException("Could not parse SimpleGeo Response. (Latitude or Longitude missing from Point geometry?)", ex);
            }

            return new Point(new Coordinate(latitude, longitude));
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Point);
        }
    }
}
