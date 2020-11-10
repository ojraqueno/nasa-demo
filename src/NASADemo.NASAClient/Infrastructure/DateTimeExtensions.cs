using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("NASADemo.NASAClient.Tests")]
namespace NASADemo.NASAClient.Infrastructure
{
    internal static class DateTimeExtensions
    {
        internal static string ToNASADateString(this DateTime dt) =>
            dt.ToString(Settings.DATE_FORMAT);
    }
}