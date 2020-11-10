using NASADemo.NASAClient.Features;
using System;
using System.Threading.Tasks;

namespace NASADemo.NASAClient
{
    internal sealed class NASAClient : INASAClient
    {
        private readonly string _apiKey;

        internal NASAClient(string apiKey)
        {
            if (String.IsNullOrWhiteSpace(apiKey)) throw new ArgumentNullException(nameof(apiKey));

            _apiKey = apiKey;
        }

        public async Task<GetMarsRoverPhotoByEarthDate.Response> GetMarsRoverPhotoByEarthDate(GetMarsRoverPhotoByEarthDate.Request request) =>
            await (new GetMarsRoverPhotoByEarthDate.Handler()).Handle(request, _apiKey);
    }
}