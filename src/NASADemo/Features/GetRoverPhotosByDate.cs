using FluentValidation;
using Flurl.Http;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NASADemo.Infrastructure.NET;
using NASADemo.Infrastructure.Web;
using NASADemo.NASAClient;
using NASADemo.NASAClient.Features;
using NASADemo.NASAClient.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NASADemo.Features
{
    public class GetRoverPhotosByDate
    {
        public class Request : IRequest<Response>
        {
            public IFormFile File { get; set; }
        }

        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(r => r.File)
                    .NotNull()
                    .WithMessage("File cannot be null.");
            }
        }

        public class Response
        {
            public List<DownloadedFile> DownloadedFiles { get; set; } = new List<DownloadedFile>();

            public class DownloadedFile
            {
                public DownloadedFile(int id, string imageUrl, string physicalPath)
                {
                    Id = id;
                    ImageUrl = imageUrl;
                    PhysicalPath = physicalPath;
                }

                public int Id { get; }
                public string ImageUrl { get; }
                public string PhysicalPath { get; }
            }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IHostingEnvironment _hostingEnvironment;
            private readonly INASAClient _nasaClient;

            public Handler(IHostingEnvironment hostingEnvironment, INASAClient nasaClient)
            {
                ExceptionHelper.Argument.ThrowIfNull(hostingEnvironment, nameof(hostingEnvironment));
                ExceptionHelper.Argument.ThrowIfNull(nasaClient, nameof(nasaClient));

                _hostingEnvironment = hostingEnvironment;
                _nasaClient = nasaClient;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var response = new Response();

                response.DownloadedFiles = (await request.File.ReadAllLines())
                    .Select(line => line.ToDate())
                    .WithoutNulls()
                    .SelectAsync(async date => await GetMarsRoverPhotoByEarthDate(date.Value))
                    .SelectMany(response => response.Photos)
                    .WithoutNulls()
                    .SelectAsync(async photo => await Download(photo))
                    .ToList();

                return response;
            }

            private async Task<GetMarsRoverPhotoByEarthDate.Response> GetMarsRoverPhotoByEarthDate(DateTime date)
            {
                var getMarsRoverPhotoByEarthDateRequest = new GetMarsRoverPhotoByEarthDate.Request
                {
                    RoverName = "curiosity",
                    EarthDate = date
                };

                return await _nasaClient.GetMarsRoverPhotoByEarthDate(getMarsRoverPhotoByEarthDateRequest);
            }

            private async Task<Response.DownloadedFile> Download(Photo photo)
            {
                var savePath = Path.Combine(_hostingEnvironment.WebRootPath, "NASAImages");

                await photo.ImageSource.DownloadFileAsync(savePath);

                return new Response.DownloadedFile(photo.Id, photo.ImageSource, savePath);
            }
        }
    }
}