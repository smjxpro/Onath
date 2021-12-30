namespace Onath.Web.Services;

public interface IFileService
{
    string Upload(IFormFile file, string directory);
    void Delete(string url, string directory);
    
    
}