using Microsoft.AspNetCore.Http;
using NASADemo.Infrastructure.NET;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NASADemo.Infrastructure.Web
{
    public static class IFormFileExtensions
    {
        public static async Task<List<string>> ReadAllLines(this IFormFile file)
        {
            ExceptionHelper.Argument.ThrowIfNull(file, nameof(file));

            var lines = new List<string>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    lines.Add(await reader.ReadLineAsync());
                }
            }

            return lines;
        }
    }
}