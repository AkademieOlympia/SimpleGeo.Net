﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PolygonConverter.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   Defines the PolygonConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleGeo.Net.Helpers.Json.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;

    using SimpleGeo.Net.Exceptions;

    /// <summary>
    /// Converter to read and write the <see cref="MultiPolygon" /> type.
    /// </summary>
    public class PolygonConverter : JsonConverter
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
            var pointsArray = (JArray)serializer.Deserialize(reader);

            if (pointsArray == null || pointsArray.Count != 1)
            {
                throw new ParsingException("Polygon geometry coordinates could not be parsed.");
            }

            var points = new List<Point>();
            var parsingErrors = new List<Exception>();

            var polygonDeserializerSettings = new JsonSerializerSettings
            {
                Error = delegate(object sender, ErrorEventArgs args)
                {
                    parsingErrors.Add(args.ErrorContext.Error);
                    args.ErrorContext.Handled = true;
                },
                Converters = { new PointConverter() }
            };
            points.AddRange(JsonConvert.DeserializeObject<List<Point>>(
                pointsArray.First.ToString(),
                polygonDeserializerSettings));

            if (parsingErrors.Any())
            {
                throw new AggregateException("Error parsing Geometry.", parsingErrors);
            }

            return new Polygon(points);
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
            return objectType == typeof(Polygon);
        }
    }
}
