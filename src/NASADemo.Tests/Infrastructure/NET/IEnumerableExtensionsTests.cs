using NASADemo.Infrastructure.NET;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NASADemo.Tests.Infrastructure.NET
{
    public class IEnumerableExtensionsTests
    {
        [Fact]
        public void WithoutNulls_ShouldFilterOutNulls_GivenReferenceType()
        {
            var list = new List<string> { "abc", "def", null };

            var withoutNulls = list.WithoutNulls().ToList();

            Assert.Equal(2, withoutNulls.Count);
            Assert.True(withoutNulls.TrueForAll(s => s != null));
        }

        [Fact]
        public void WithoutNulls_ShouldFilterOutNulls_GivenNullableType()
        {
            var list = new List<int?> { 1, 2, null };

            var withoutNulls = list.WithoutNulls().ToList();

            Assert.Equal(2, withoutNulls.Count);
            Assert.True(withoutNulls.TrueForAll(s => s != null));
        }
    }
}