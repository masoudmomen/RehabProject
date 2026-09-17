using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Blog
{
    public class BlogPostFilter
    {
 
        public string? TagSlug { get; set; }
        public string? TopicSlug { get; set; }
        public string? SearchTerm { get; set; }

        public bool ExcludeFeatured { get; set; }
        public bool IsEmpty =>
          
            string.IsNullOrWhiteSpace(TagSlug) &&
            string.IsNullOrWhiteSpace(TopicSlug) &&
            string.IsNullOrWhiteSpace(SearchTerm);
    }
}
