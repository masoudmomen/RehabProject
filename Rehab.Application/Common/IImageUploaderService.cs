using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;


namespace Rehab.Application.Common
{
    public interface IImageUploaderService
    {
        Task<List<string>> UploadAsync(IEnumerable<IBrowserFile> files, string webRootPath, string relativePath, CancellationToken cancellationToken = default);

        Task<string> UploadAsync(byte[] fileBytes, string fileName, string webRootPath, string relativePath, CancellationToken cancellationToken = default);
    }

    public class ImageUploaderService : IImageUploaderService
    {
        public async Task<List<string>> UploadAsync(IEnumerable<IBrowserFile> files, string webRootPath, string relativePath, CancellationToken cancellationToken = default)
        {
            var savedFilePaths = new List<string>();
            string folderPath = Path.Combine(webRootPath, relativePath);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            foreach (var file in files)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.Name)}";
                var filePath = Path.Combine(folderPath, fileName);

                await using var stream = file.OpenReadStream(10 * 1024 * 1024); // 10MB max
                await using var fileStream = new FileStream(filePath, FileMode.Create);
                await stream.CopyToAsync(fileStream, cancellationToken);

                savedFilePaths.Add(Path.Combine(relativePath, fileName).Replace("\\", "/"));
            }

            return savedFilePaths;
        }


        public async Task<string> UploadAsync(byte[] fileBytes, string fileName, string webRootPath, string relativePath, CancellationToken cancellationToken = default)
        {
            string folderPath = Path.Combine(webRootPath, relativePath);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(fileName)}";
            var filePath = Path.Combine(folderPath, uniqueFileName);

            await File.WriteAllBytesAsync(filePath, fileBytes, cancellationToken);

            return Path.Combine(relativePath, uniqueFileName).Replace("\\", "/");
        }

    }
}
