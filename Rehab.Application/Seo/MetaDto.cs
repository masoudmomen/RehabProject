using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Seo
{
    public class MetaDto
    {
        public short Id { get; set; }
        public string PageName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public List<string>? Keywords { get; set; }
    }
}
