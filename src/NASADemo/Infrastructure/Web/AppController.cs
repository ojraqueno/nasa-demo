using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NASADemo.Infrastructure.Web
{
    public abstract class AppController : Controller
    {
        private readonly IMediator _mediator;

        public AppController(IMediator mediator) =>
            _mediator = mediator;

        /// <summary>
        /// Processes the incoming request and wraps the response in an OkObjectResult and returns it. An invalid ModelState returns a BadRequest.
        /// </summary>
        protected async Task<IActionResult> Ok<TResponse>(IRequest<TResponse> request) =>
            request switch
            {
                null => throw new ArgumentNullException(nameof(request)),
                _ => await ValidateAndExecute(async () => Ok(await GetResponse(request)))
            };

        /// <summary>
        /// Processes the incoming request, then redirects to the provided action and controller. An invalid ModelState returns a BadRequest.
        /// </summary>
        protected async Task<IActionResult> RedirectToAction<TResponse>(IRequest<TResponse> request, string actionName, string controllerName) =>
            request switch
            {
                null => throw new ArgumentNullException(nameof(request)),
                _ => await ValidateAndExecute(async () => { await GetResponse(request); return RedirectToAction(actionName, controllerName); })
            };

        /// <summary>
        /// Executes some actions before returning the View.
        /// </summary>
        protected IActionResult View(Action preActions)
        {
            preActions();

            return View();
        }

        /// <summary>
        /// Processes the incoming request and wraps the response in a ViewResult and returns it.
        /// </summary>
        protected async Task<IActionResult> View<TResponse>(IRequest<TResponse> request) =>
            request switch
            {
                null => throw new ArgumentNullException(nameof(request)),
                _ => View(await GetResponse(request))
            };

        /// <summary>
        /// Processes a request and returns the response.
        /// </summary>
        private async Task<TResponse> GetResponse<TResponse>(IRequest<TResponse> request) =>
            request switch
            {
                null => throw new ArgumentNullException(nameof(request)),
                _ => await _mediator.Send(request)
            };

        /// <summary>
        /// Validates ModelState and executes the action if the ModelState is valid.
        /// </summary>
        private async Task<IActionResult> ValidateAndExecute(Func<Task<IActionResult>> action) =>
            ModelState.IsValid switch
            {
                true => await action(),
                false => BadRequest(ModelState)
            };
    }
}