using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Common
{
    public record ClaimForModelDto(
      string IsFacilityListed,
      string FacilityName,
      string? FacilityAddress,
      string? FacilityWebsite,
      string? AdmissionsPhone,
      string? AdmissionsEmail,
      string? PrimaryLevelOfCare,
      string ContactName,
      string WorkEmail,
      string? RoleOrConnection,
      string? ContactPhone,
      string? AdditionalInformation
  );
}
