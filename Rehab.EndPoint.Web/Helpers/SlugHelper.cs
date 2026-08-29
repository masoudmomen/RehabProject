namespace Rehab.EndPoint.Web.Helpers
{
    public class SlugHelper
    {
        public static string ToSlug(string name) =>
               string.IsNullOrWhiteSpace(name) ? string.Empty : name.Trim().ToLowerInvariant().Replace(" ", "-");
    }
}
