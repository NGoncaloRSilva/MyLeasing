using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyLeasing.Common.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string folder);
    }
}