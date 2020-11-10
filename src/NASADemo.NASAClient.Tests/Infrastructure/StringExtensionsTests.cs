using NASADemo.NASAClient.Infrastructure;
using System;
using Xunit;

namespace NASADemo.NASAClient.Tests.Infrastructure
{
    public class StringExtensionsTests
    {
        [Fact]
        public void ToNASADate_ShouldReturnNull_GivenNullInput()
        {
            var input = (string)null;

            var nasaDate = input.ToNASADate();

            Assert.Null(nasaDate);
        }

        [Fact]
        public void ToNASADate_ShouldReturnNull_GivenEmptyInput()
        {
            var input = "";

            var nasaDate = input.ToNASADate();

            Assert.Null(nasaDate);
        }

        [Fact]
        public void ToNASADate_ShouldReturnNull_GivenInvalidInput()
        {
            var input = "asdf";

            var nasaDate = input.ToNASADate();

            Assert.Null(nasaDate);
        }

        [Fact]
        public void ToNASADate_ShouldReturnNonNull_GivenWellFormattedInput()
        {
            var input = "2020-11-15";

            var nasaDate = input.ToNASADate();

            Assert.True(nasaDate.HasValue);
            Assert.Equal(new DateTime(2020, 11, 15), nasaDate.Value);
        }
    }
}
