using NASADemo.Infrastructure.NET;
using System;
using Xunit;

namespace NASADemo.Tests.Infrastructure.NET
{
    public class ExceptionHelperTests
    {
        [Fact]
        public void ThrowIfNull_ShouldThrowArgumentNullException_GivenNull()
        {
            var item = (string)null;

            Assert.Throws<ArgumentNullException>(() => ExceptionHelper.Argument.ThrowIfNull(item, nameof(item)));
        }
    }
}