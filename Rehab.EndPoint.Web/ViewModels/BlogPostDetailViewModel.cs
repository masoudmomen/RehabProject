using Microsoft.IdentityModel.Logging;
using Rehab.Application.Blog;
using Rehab.Application.Tags;
using Rehab.Domain.Blog;
using Rehab.EndPoint.Web.Helpers;

namespace Rehab.EndPoint.Web.ViewModels
{
    public class BlogPostDetailViewModel
    {
        public int Id { get; init; } = 0;

        public string Title { get; init; } = string.Empty;
        public string Slug { get; init; } = string.Empty;
        public string? Description { get; init; }
        public string Content { get; init; } = string.Empty;
        public string? ImageUrl { get; init; }

        public int TimeToRead { get; init; }
        public DateTime PublisheDate { get; init; }
        public string? AuthorName { get; init; } = "RehabNavigator";
        public string? AuthorAvatarUrl { get; init; }

        public List<BlogTagDto> Tags { get; init; } = new();
        public List<TopicViewModel> Topics { get; init; } = new();

        // computed, no mapping needed
        public string ReadTimeDisplay => $"{TimeToRead} min read";
        public string PublishedDisplay => PublisheDate.ToString("MMM d");

        public string TagSlug(BlogTagDto tag) => SlugHelper.ToSlug(tag.Name);
 
    }
}
