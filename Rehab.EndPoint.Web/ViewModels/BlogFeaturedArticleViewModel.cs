namespace Rehab.EndPoint.Web.ViewModels
{
    public class BlogFeaturedArticleViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string PublishedDate { get; set; } = string.Empty; public List<string> Topics { get; set; } = new();

        public string AuthorName { get; set; } = string.Empty;
        public string AuthorRole { get; set; } = string.Empty;
        public string AuthorInitials { get; set; } = string.Empty;
    }

}
