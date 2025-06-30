using AutoMapper;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Domain.Insurances;
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
        List<InsuranceDto> GetList();
        BaseDto<InsuranceDto> Update(InsuranceDto insurance);

        BaseDto<InsuranceDto> Delete(InsuranceDto insurance);
    }

    public class InsuranceService : IInsuranceService
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;

        public InsuranceService(IDatabaseContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public BaseDto<InsuranceDto> Add(InsuranceDto insurance)
        {
            if (insurance == null) return BaseDto<InsuranceDto>.FailureResult("The Insurance data is null!");

            context.Insurances.Add(mapper.Map<Insurance>(insurance));
            if (context.SaveChanges() > 0) return BaseDto<InsuranceDto>.SuccessResult(insurance, "Insurance Added successfully.");

            return BaseDto<InsuranceDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public BaseDto<InsuranceDto> Delete(InsuranceDto insurance)
        {
            if (insurance is null) return BaseDto<InsuranceDto>.FailureResult("The Insurance data is null!");

            var result = context.Insurances.FirstOrDefault(c => c.Id == insurance.Id);
            if (result == null) return BaseDto<InsuranceDto>.FailureResult("The Insurance not find!");

            context.Insurances.Remove(result);
            if (context.SaveChanges() > 0) return BaseDto<InsuranceDto>.SuccessResult(insurance, "Insurance Deleted successfully.");

            return BaseDto<InsuranceDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public List<InsuranceDto> GetList()
        {
            return mapper.Map<List<InsuranceDto>>(context.Insurances.OrderBy(c => c.Name).ToList());
        }

        public BaseDto<InsuranceDto> Update(InsuranceDto insurance)
        {
            if (insurance == null) return BaseDto<InsuranceDto>.FailureResult("The Insurance data is null!");

            var insuranceForUpdate = context.Insurances.Find(insurance.Id);
            if(insuranceForUpdate is null) return BaseDto<InsuranceDto>.FailureResult("The Insurance not find!");

            if (insurance.Logo == "") insurance.Logo = insuranceForUpdate.Logo;
            mapper.Map(insurance, insuranceForUpdate);
            //context.Insurances.Update(insuranceForUpdate);
            if (context.SaveChanges() > 0) return BaseDto<InsuranceDto>.SuccessResult(insurance, "Insurance Updated successfully.");

            return BaseDto<InsuranceDto>.FailureResult("Operation Failed! Please try another time!");
        }
    }

    public class InsuranceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
