using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Rehab.Domain.Blog;
using System.ComponentModel.DataAnnotations;

namespace Rehab.EndPoint.AdminPanel.Viewmodels
{
    public class BlogPostViewmodel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required(ErrorMessage = "Main Content is required!")]
        public string Content { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public int TimeToRead { get; set; }
        public bool IsFetured { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime PublisheDate { get; set; } = DateTime.UtcNow;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public List<BlogPostTagViewModel>? TagList { get; set; }
        public List<int> TagsId { get; set; } = new();
        public List<BlogPostTopicViewModel>? Topics { get; set; }
        public List<int> TopicsId { get; set; } = new();
        public List<int> CommentsId { get; set; } = new();
    }
}
