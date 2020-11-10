using NASADemo.Infrastructure.NET;
using System;
using Xunit;

namespace NASADemo.Tests.Infrastructure.NET
{
    public class StringExtensionsTests
    {
        [Fact]
        public void ToDate_ShouldReturnDate_GivenValidFormat01()
        {
            var input = "02/27/17";

            var date = input.ToDate();

            Assert.True(date.HasValue);
            Assert.Equal(new DateTime(2017, 2, 27), date.Value);
        }

        [Fact]
        public void ToDate_ShouldReturnDate_GivenValidFormat02()
        {
            var input = "June 2, 2018";

            var date = input.ToDate();

            Assert.True(date.HasValue);
            Assert.Equal(new DateTime(2018, 6, 2), date.Value);
        }

        [Fact]
        public void ToDate_ShouldReturnDate_GivenValidFormat03()
        {
            var input = "Jul-13-2016";

            var date = input.ToDate();

            Assert.True(date.HasValue);
            Assert.Equal(new DateTime(2016, 7, 13), date.Value);
        }

        [Fact]
        public void ToDate_ShouldReturnDate_GivenValidFormat04()
        {
            var input = "August 30, 2020";

            var date = input.ToDate();

            Assert.True(date.HasValue);
            Assert.Equal(new DateTime(2020, 8, 30), date.Value);
        }
    }
}