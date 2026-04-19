using Rehab.Domain.Blog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Blog
{
    public class BlogPostDto
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
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public List<BlogTagDto>? TagList { get; set; } 
        public List<int>? TagsId { get; set; } = new();
        public List<int>? TopicsId { get; set; } = new();
        public List<int>? CommentsId { get; set; } = new();
    }
}
