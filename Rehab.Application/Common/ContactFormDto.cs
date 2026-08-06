using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Common
{
    public record ContactFormDto(
       string InquiryType,
       string Name,
       string Email,
       string? Phone,
       string? FacilityName,
       string Message
    );
}
