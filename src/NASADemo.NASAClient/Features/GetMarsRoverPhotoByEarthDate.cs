using Flurl;
using Flurl.Http;
using NASADemo.NASAClient.Infrastructure;
using NASADemo.NASAClient.Model;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NASADemo.NASAClient.Features
{
    public sealed class GetMarsRoverPhotoByEarthDate
    {
        public sealed class Request
        {
            public string RoverName { get; set; }
            public DateTime EarthDate { get; set; }
            public string CameraName { get; set; }
            public int? Page { get; set; }
        }

        public sealed class Response
        {
            [JsonPropertyName("photos")]
            public List<Photo> Photos { get; set; } = new List<Photo>();
        }

        internal sealed class Handler
        {
            public async Task<Response> Handle(Request request, string apiKey)
            {
                if (request == null) throw new ArgumentNullException(nameof(request));
                if (request.RoverName == null) throw new ArgumentNullException(nameof(request.RoverName));

                // sample: https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?earth_date=2015-6-3&api_key=DEMO_KEY
                var stringResponse = await new Uri(Settings.API_BASE)
                    .AppendPathSegment("mars-photos/api/v1/rovers/")
                    .AppendPathSegment(request.RoverName)
                    .AppendPathSegment("photos")
                    .SetQueryParams(new { earth_date = request.EarthDate.ToNASADateString(), camera = request.CameraName, page = request.Page, api_key = apiKey })
                    .GetStringAsync();

                return JsonSerializer.Deserialize<Response>(stringResponse);
            }
        }
    }
}