// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTime.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   DateTime related Helper methods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleGeo.Net.Helpers
{
    using System;

    /// <summary>
    /// DateTime related Helper methods.
    /// </summary>
    internal static class DateTime
    {
        /// <summary>
        /// Converts a given unix timestamp to its <c>System.DateTime</c> representation.
        /// </summary>
        /// <param name="timestamp">The timestamp to convert.</param>
        /// <returns>An instance of <c>System.DateTime</c></returns>
        internal static System.DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            return dateTime.AddSeconds(timestamp);
        }

        /// <summary>
        /// Converts the given <c>System.DateTime</c> to its unix timestamp.
        /// </summary>
        /// <param name="date">The <c>System.DateTime</c> to convert.</param>
        /// <returns>An unix timestamp in the <c>System.Double</c> format.</returns>
        internal static double ConvertToUnixTimestamp(System.DateTime date)
        {
            var dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            var timeSpan = date - dateTime;
            return Math.Floor(timeSpan.TotalSeconds);
        }
    }
}
