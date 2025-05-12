using Rehab.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Insurances
{
    public interface IInsuranceService
    {
        BaseDto<InsuranceDto> Add(InsuranceDto insurance);
    }

    public class InsuranceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
