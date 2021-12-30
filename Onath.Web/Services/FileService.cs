namespace Onath.Web.Services;

public class FileService: IFileService
{
    private readonly IWebHostEnvironment _environment;

    public FileService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }
    public string Upload(IFormFile file, string directory)
    {
      
            if (file == null) return null;
            var uploadsDirectory = Path.Combine(_environment.WebRootPath, "uploads", directory);
            var uniqueFileName = Guid.NewGuid() + "." + file.FileName.Split(".").Last();
            var filePath = Path.Combine(uploadsDirectory, uniqueFileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);

            var url = $"/uploads/{directory}/{uniqueFileName}";
            return url;
        
    }

    public void Delete(string url, string directory)
    {
      
            var filePath = Path.Combine(_environment.WebRootPath, "uploads", directory,url.Split("/").Last());


            if (!File.Exists(filePath)) return;

            File.Delete(filePath);
       
    }
}