using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("NASADemo.Tests")]
namespace NASADemo.Infrastructure.NET
{
    internal static class IEnumerableExtensions
    {
        internal static IEnumerable<TResult> SelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
        {
            ExceptionHelper.Argument.ThrowIfNull(source, nameof(source));
            ExceptionHelper.Argument.ThrowIfNull(selector, nameof(selector));

            return source.Select(selector).Select(s => s.Result);
        }

        internal static IEnumerable<TSource> WithoutNulls<TSource>(this IEnumerable<TSource> source) where TSource : class
        {
            ExceptionHelper.Argument.ThrowIfNull(source, nameof(source));

            return source.Where(i => i != null);
        }

        internal static IEnumerable<T?> WithoutNulls<T>(this IEnumerable<Nullable<T>> source) where T : struct
        {
            ExceptionHelper.Argument.ThrowIfNull(source, nameof(source));

            return source.Where(i => i.HasValue);
        }
    }
}