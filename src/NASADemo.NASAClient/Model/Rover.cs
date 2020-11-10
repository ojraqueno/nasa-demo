using NASADemo.NASAClient.Infrastructure;
using System;
using System.Text.Json.Serialization;

namespace NASADemo.NASAClient.Model
{
    public sealed class Rover
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("landing_date")]
        public string LandingDate { get; set; }

        [JsonPropertyName("launch_date")]
        public string LaunchDate { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonIgnore]
        public DateTime? LandingDateParsed => LandingDate.ToNASADate();

        [JsonIgnore]
        public DateTime? LaunchDateParsed => LaunchDate.ToNASADate();
    }
}