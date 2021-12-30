namespace Onath.Web.ViewModels;

public class CreateWallpaperVM
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public IFormFile File { get; set; }
}