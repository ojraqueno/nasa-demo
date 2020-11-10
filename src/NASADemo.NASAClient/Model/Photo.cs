using NASADemo.NASAClient.Infrastructure;
using System;
using System.Text.Json.Serialization;

namespace NASADemo.NASAClient.Model
{
    public sealed class Photo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("sol")]
        public int Sol { get; set; }

        [JsonPropertyName("camera")]
        public Camera Camera { get; set; }

        [JsonPropertyName("img_src")]
        public string ImageSource { get; set; }

        [JsonPropertyName("earth_date")]
        public string EarthDate { get; set; }

        [JsonPropertyName("rover")]
        public Rover Rover { get; set; }
        
        [JsonIgnore]
        public DateTime? EarthDateParsed => EarthDate.ToNASADate();
    }
}