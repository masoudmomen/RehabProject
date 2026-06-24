using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Common
{
    public record AdvertiseContactDto(
     string FacilityName,
     string ContactName,
     string Email,
     string? HelpTopic,
     string? Message
 );
}
