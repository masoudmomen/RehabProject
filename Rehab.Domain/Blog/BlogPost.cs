using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Domain.Blog
{
    public class BlogPost
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public int TimeToRead { get; set; }
        public bool IsFetured { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime PublisheDate { get; set; } = DateTime.UtcNow;
        public DateTime CreatedDate {  get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public List<BlogPostTag> Tags { get;set; } = new List<BlogPostTag>();
        public List<BlogPostTopic> Topics { get; set; } = new List<BlogPostTopic>();
        public List<BlogPostComment> Comments { get; set; } = new List<BlogPostComment>();
    }
}
