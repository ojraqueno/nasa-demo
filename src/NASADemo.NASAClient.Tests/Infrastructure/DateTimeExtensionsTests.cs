using NASADemo.NASAClient.Infrastructure;
using System;
using Xunit;

namespace NASADemo.NASAClient.Tests.Infrastructure
{
    public class DateTimeExtensionsTests
    {
        [Fact]
        public void ToNASADateString_ShouldReturnDateInNASAFormat()
        {
            var dt = new DateTime(2020, 11, 15);

            var nasaDateString = dt.ToNASADateString();

            Assert.Equal("2020-11-15", nasaDateString);
        }
    }
}