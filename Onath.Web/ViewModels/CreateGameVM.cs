namespace Onath.Web.ViewModels;

public class CreateGameVM
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
    public IFormFile CoverPhoto { get; set; }
    public IFormFile File { get; set; }
}