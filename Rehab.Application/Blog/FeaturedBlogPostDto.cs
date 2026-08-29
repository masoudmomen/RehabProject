using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Blog
{
    public class FeaturedBlogPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int TimeToRead { get; set; }
        public DateTime PublisheDate { get; set; }
        public List<string> Topics { get; set; } = new();
    }

}
