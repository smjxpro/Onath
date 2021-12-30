namespace Onath.Web.ViewModels;

public class CreateMusicVM
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }
    public IFormFile File { get; set; }
}