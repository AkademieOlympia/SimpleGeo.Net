// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Handle.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   Defines the Handle type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleGeo.Net
{
    using System;
    using System.Globalization;
    using System.Text;

    using SimpleGeo.Net.ExtensionMethods;

    /// <summary>
    /// A SimpleGeo handle uniquely identifies a <see cref="Feature"/>
    /// </summary>
    /// <seealso cref="http://simplegeo.com/docs/getting-started/simplegeo-101#handle"/>
    public class Handle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Handle"/> class.
        /// </summary>
        /// <param name="uniqueString">The unique string.</param>
        /// <param name="approximateLocation">The approximate location.</param>
        /// <param name="epoch">The epoch which will be converted to Unix Timestamp internally.</param>
        public Handle(string uniqueString, Coordinate approximateLocation = null, DateTime? epoch = null)
        {
            if (uniqueString == null)
            {
                throw new ArgumentNullException("uniqueString");
            }

            if (string.IsNullOrWhiteSpace(uniqueString))
            {
                throw new ArgumentOutOfRangeException("uniqueString", "Must contain an unique string");
            }

            this.UniqueString = uniqueString;

            if (approximateLocation != null)
            {
                this.ApproximateLocation = approximateLocation;
            }

            if (epoch != null)
            {
                this.Epoch = epoch.GetValueOrDefault();
            }
        }

        /// <summary>
        /// Gets the unique string.
        /// </summary>
        /// <value>The unique string.</value>
        public string UniqueString { get; private set; }

        /// <summary>
        /// Gets the approximate location.
        /// </summary>
        /// <value>The approximate location.</value>
        public Coordinate ApproximateLocation { get; private set; }

        /// <summary>
        /// Gets the epoch.
        /// </summary>
        /// <value>The epoch.</value>
        public DateTime? Epoch { get; private set; }

        /// <summary>
        /// Tries to parse the given string into a <c>Handle</c>. Expected format is
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <returns>An instance of <c>Handle</c> if it could be parsed, otherwise null</returns>
        public static Handle TryParse(string handle)
        {
            return Parse(handle, false);
        }

        /// <summary>
        /// Parses the specified handle and returns an proper instance.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <returns>An instance of the <c>Handle</c> type.</returns>
        /// <exception cref="ArgumentOutOfRangeException">In case the given handle string cannot be parsed, this exception will be thrown with further details.</exception>
        public static Handle Parse(string handle)
        {
            return Parse(handle, true);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance in compliance with <see cref="http://simplegeo.com/docs/getting-started/simplegeo-101#handle"/>.
        /// </returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("SG");
            stringBuilder.Append("_");
            stringBuilder.Append(this.UniqueString);

            if (this.ApproximateLocation != null)
            {
                stringBuilder.Append("_");
                stringBuilder.Append(this.ApproximateLocation.Latitude.ToString(CultureInfo.InvariantCulture));
                stringBuilder.Append("_");
                stringBuilder.Append(this.ApproximateLocation.Longitude.ToString(CultureInfo.InvariantCulture));
            }

            if (this.Epoch != null)
            {
                stringBuilder.Append("@");
                stringBuilder.Append(Convert.ToInt32(Helpers.DateTime.ConvertToUnixTimestamp(this.Epoch.GetValueOrDefault())));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Parses the specified handle.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <param name="throwException">if set to <c>true</c> throws exception.</param>
        /// <exception cref="ArgumentOutOfRangeException">In case the given handle string cannot be parsed, this exception will be thrown with further details.</exception>
        /// <returns>An instance of <c>Handle</c> if it could be parsed, otherwise null</returns>
        internal static Handle Parse(string handle, bool throwException)
        {
            if (handle == null)
            {
                if (throwException)
                {
                    throw new ArgumentNullException("handle");
                }

                return null;
            }

            if (string.IsNullOrWhiteSpace(handle))
            {
                if (throwException)
                {
                    throw new ArgumentOutOfRangeException("handle", "May not be empty");
                }

                return null;
            }

            if (!handle.StartsWith("SG_", false, CultureInfo.InvariantCulture))
            {
                if (throwException)
                {
                    throw new ArgumentOutOfRangeException("handle", "Must start with 'SG_'. See 'http://simplegeo.com/docs/getting-started/simplegeo-101#handle' for Handle format description.");
                }

                return null;
            }

            Coordinate handleCoordinate = null;
            DateTime? epochTime = null;

            // 1. split given handle on its epoch preceding '@' (or not)
            var primarySplit = handle.Split("@".ToCharArray());

            var epochString = primarySplit.TryGetValue<string>(1);

            if (!string.IsNullOrWhiteSpace(epochString))
            {
                double epoch;
                if (!double.TryParse(epochString, out epoch))
                {
                    throw new ArgumentOutOfRangeException("handle", "Epoch must be a proper Unix Timestamp. See 'http://simplegeo.com/docs/getting-started/simplegeo-101#handle' for Handle format description.");
                }

                try
                {
                    epochTime = Helpers.DateTime.ConvertFromUnixTimestamp(epoch);
                }
                catch (Exception)
                {
                    if (throwException)
                    {
                        throw;
                    }

                    return null;
                }
            }

            // 2. we try to parse the first part
            var secondarySplit = primarySplit[0].Split("_".ToCharArray());

            // we can safely ignore secondarySplit[0] as it has been tested for existance already

            // get uniqueString
            var uniqueString = secondarySplit.TryGetValue<string>(1);

            if (string.IsNullOrWhiteSpace(uniqueString))
            {
                if (throwException)
                {
                    throw new ArgumentOutOfRangeException("handle", "Must contain a unique string. See 'http://simplegeo.com/docs/getting-started/simplegeo-101#handle' for Handle format description.");
                }

                return null;
            }

            // now check for latitude or longitude
            var latitudeString = secondarySplit.TryGetValue<string>(2);
            var longitudeString = secondarySplit.TryGetValue<string>(3);

            if (!string.IsNullOrWhiteSpace(latitudeString) && !string.IsNullOrWhiteSpace(longitudeString))
            {
                double latitude;
                double longitude;

                if (!double.TryParse(latitudeString, NumberStyles.Float, CultureInfo.InvariantCulture, out latitude))
                {
                    throw new ArgumentOutOfRangeException("handle", "Latitude must be a proper lat (+/- double) value. See 'http://simplegeo.com/docs/getting-started/simplegeo-101#handle' for Handle format description.");
                }

                if (!double.TryParse(longitudeString, NumberStyles.Float, CultureInfo.InvariantCulture, out longitude))
                {
                    throw new ArgumentOutOfRangeException("handle", "Longitude must be a proper lon (+/- double) value. See 'http://simplegeo.com/docs/getting-started/simplegeo-101#handle' for Handle format description.");
                }

                handleCoordinate = new Coordinate(latitude, longitude);
            }
            else if ((latitudeString != null && longitudeString == null) ||
                (latitudeString == null && longitudeString != null))
            {
                if (throwException)
                {
                    throw new ArgumentOutOfRangeException("handle", "If an approximate location part is available, both (latitude AND longitude) must be present. See 'http://simplegeo.com/docs/getting-started/simplegeo-101#handle' for Handle format description.");
                }

                return null;
            }

            // oh look we made it..
            return new Handle(uniqueString, handleCoordinate, epochTime);
        }
    }
}
