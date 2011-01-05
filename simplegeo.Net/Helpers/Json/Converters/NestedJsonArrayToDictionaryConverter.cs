// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedJsonArrayToDictionaryConverter.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   Defines the NestedJsonArrayToDictionaryConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleGeo.Net.Helpers.Json.Converters
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Utilities;

    /// <summary>
    /// Converter used to (de)serialize the 'properties' part of a <c>Feature</c> into
    /// a .Net Dictionary&lt;string, object&gt; including probable sub-arrays into,
    /// again.. a Dictionary&lt;string, object&gt; each.
    /// </summary>
    public class NestedJsonArrayToDictionaryConverter : JsonConverter
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
            IList<Type> genericArguments = objectType.GetGenericArguments();
            Type keyType = genericArguments[0];
            Type valueType = genericArguments[1];

            reader.Read();
            reader.Read();
            object key = serializer.Deserialize(reader, keyType);
            reader.Read();
            reader.Read();
            object value = serializer.Deserialize(reader, valueType);
            reader.Read();

            return null;
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
            return objectType == typeof(Dictionary<string, object>);
        }
    }
}
