using System;
using System.Globalization;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("NASADemo.Tests")]
namespace NASADemo.Infrastructure.NET
{
    internal static class StringExtensions
    {
        internal static DateTime? ToDate(this string line)
        {
            if (String.IsNullOrWhiteSpace(line)) return null;

            var formats = new[] { "MM/dd/yy", "MMMM d, yyyy", "MMM-dd-yyyy", "MMMM dd, yyyy" };

            return DateTime.TryParseExact(line, formats, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime dt) ? dt : (DateTime?)null;
        }
    }
}