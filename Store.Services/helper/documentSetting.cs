using Microsoft.AspNetCore.Http;

namespace ECOMMERECE.helper
{
    public class documentSetting
    {
        public static string uploadFile(IFormFile file, string folderName)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);
            var fileName = $"{Guid.NewGuid()}-{file.FileName}";
            var filePath = Path.Combine(folderPath, fileName);
            using var FileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(FileStream);
            return fileName;
        }
    }
}
