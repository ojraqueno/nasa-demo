using System;

namespace NASADemo.Infrastructure.NET
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Gets the innermost exception of a given exception.
        /// </summary>
        public static Exception InnermostException(this Exception ex) =>
            ex switch
            {
                null => throw new ArgumentNullException(nameof(ex)),
                _ => ex.InnerException == null ? ex : ex.InnermostException()
            };
    }
}