namespace Rehab.Application.Blog
{
   
    public class BlogViewRequest
    {
        public int PostId { get; set; }

         public string? UserAgent { get; set; }

         public bool IsPreview { get; set; }
 
        public bool AlreadyCounted { get; set; }
    }
}
