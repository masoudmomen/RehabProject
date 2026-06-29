using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Domain.SeoEntities
{
    public class MetaContent
    {
        public short Id { get; set; }
        public string PageName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public List<string>? Keywords { get; set; }
    }
}
