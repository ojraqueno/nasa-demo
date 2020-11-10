using System;
using System.Globalization;

namespace NASADemo.NASAClient.Infrastructure
{
    internal static class StringExtensions
    {
        internal static DateTime? ToNASADate(this string input) =>
            String.IsNullOrWhiteSpace(input) || !DateTime.TryParseExact(input, Settings.DATE_FORMAT, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime nasaDate) ? (DateTime?)null : nasaDate;
    }
}