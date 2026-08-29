using Rehab.Application.Tags;
using Rehab.Domain.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Blog
{
    public class BlogPostDetailDto
    {
   
    public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Content { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public int TimeToRead { get; set; }
        public DateTime PublisheDate { get; set; }

        public string? AuthorName { get; set; }
        public string? AuthorAvatarUrl { get; set; }

        public List<BlogTagDto> Tags { get; set; } = new();
        public List<BlogTopicDto> Topics { get; set; } = new();
    }
}
 