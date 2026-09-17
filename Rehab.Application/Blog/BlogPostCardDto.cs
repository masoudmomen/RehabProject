using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Blog
{
    public class BlogPostCardDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string PublisheDate { get; set; } = string.Empty;
        public int TimeToRead { get; set; }
        public int ViewCount { get; set; }
        public List<BlogTopicDto> Topics { get; set; } = new();
        public List<BlogTagDto> Tags { get; set; } = new();
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorRole { get; set; } = string.Empty;
        public string AuthorInitials { get; set; } = string.Empty;
    }
}
 
