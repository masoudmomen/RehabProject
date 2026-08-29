using Rehab.Application.Blog;
using Rehab.EndPoint.Web.Helpers;

namespace Rehab.EndPoint.Web.ViewModels
{
    public class TopicViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;

        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TopicSlug => SlugHelper.ToSlug(Name);

    }
}
