using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NASADemo.Features;
using NASADemo.Infrastructure.Web;
using System.Threading.Tasks;

namespace NASADemo.Web.Controllers
{
    public class NASAController : AppController
    {
        public NASAController(IMediator mediator) : base(mediator)
        {
        }

        [AllowAnonymous]
        [Route("api/nasa/getRoverPhotosByDate")]
        public async Task<IActionResult> GetRoverPhotosByDate([FromForm] GetRoverPhotosByDate.Request request) => await Ok(request);
    }
}