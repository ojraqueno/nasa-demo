using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NASADemo.Infrastructure.Web;

namespace NASADemo.Web.Controllers
{
    public class HomeController : AppController
    {
        public HomeController(IMediator mediator) : base(mediator)
        {
        }

        [AllowAnonymous]
        public IActionResult Index() => View();
    }
}