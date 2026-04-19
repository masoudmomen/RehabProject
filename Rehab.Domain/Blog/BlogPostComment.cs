using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Domain.Blog
{
    public class BlogPostComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime InsetedDate { get; set; }
        public bool Display { get; set; } = false;


    }
}
