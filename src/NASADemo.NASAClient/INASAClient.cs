using NASADemo.NASAClient.Features;
using System.Threading.Tasks;

namespace NASADemo.NASAClient
{
    public interface INASAClient
    {
        Task<GetMarsRoverPhotoByEarthDate.Response> GetMarsRoverPhotoByEarthDate(GetMarsRoverPhotoByEarthDate.Request request);
    }
}