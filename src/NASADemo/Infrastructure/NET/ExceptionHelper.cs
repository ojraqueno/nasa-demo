using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("NASADemo.Tests")]
namespace NASADemo.Infrastructure.NET
{
    internal static class ExceptionHelper
    {
        internal static class Argument
        {
            /// <summary>
            /// Throws an ArgumentNullException if the given object is null.
            /// </summary>
            public static void ThrowIfNull(object value, string paramName)
            {
                if (value == null) throw new ArgumentNullException(paramName);
            }
        }
    }
}