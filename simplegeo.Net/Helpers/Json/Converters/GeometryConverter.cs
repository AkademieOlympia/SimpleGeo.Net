// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeometryConverter.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   Defines the GeometryConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleGeo.Net.Helpers.Json.Converters
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Defines the Geometry type. Converts to/from a SimpleGeo 'geometry' field
    /// </summary>
    public class GeometryConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param><param name="value">The value.</param><param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
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
            var geometry = serializer.Deserialize<Dictionary<string, object>>(reader);
            switch ((string)geometry["type"])
            {
                case null:
                    return null;
                    break;
                case "Point":
                    var coordinates = (JArray)geometry["coordinates"];
                    var latitude = coordinates.First.ToString();
                    var longitude = coordinates.Last.ToString();
                    return new Point(new Coordinate(latitude, longitude));
                    break;
                case "Polygon":
                    break;
                case "MultiPolygon":
                    break;
                default:
                    break;
            }

            return Handle.TryParse(serializer.Deserialize<string>(reader));
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
            if (objectType.IsInterface)
            {
                return objectType == typeof(IGeometry);
            }

            return objectType.GetInterface(typeof(IGeometry).Name, true) != null;
        }
    }
}
