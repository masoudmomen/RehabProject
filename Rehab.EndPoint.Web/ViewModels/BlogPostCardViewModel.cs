using Rehab.Application.Blog;
using Rehab.EndPoint.Web.Helpers;

namespace Rehab.EndPoint.Web.ViewModels
{
    public class BlogPostCardViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime PublisheDate { get; set; }
        public int TimeToRead { get; set; }
        public List<TopicViewModel> Topics { get; set; } = new();
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorRole { get; set; } = string.Empty;
        public string AuthorInitials { get; set; } = string.Empty;
        // computed, no mapping needed
        public string ReadTimeDisplay => $"{TimeToRead} min read";
        public string PublishedDisplay => PublisheDate.ToString("MMM d");

        public string TagSlug(BlogTagDto tag) => SlugHelper.ToSlug(tag.Name);

    }
}
