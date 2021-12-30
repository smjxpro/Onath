namespace Onath.Web.ViewModels;

public class CreateAppVM
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public IFormFile CoverPhoto { get; set; }
    public IFormFile File { get; set; }
}