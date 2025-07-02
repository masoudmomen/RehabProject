using AutoMapper;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Domain.Treatments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Treatments
{
    public interface ITreatmentService
    {
        BaseDto<TreatmentDto> Add(TreatmentDto treatment);
        List<TreatmentDto> GetList();
        BaseDto<TreatmentDto> Update(TreatmentDto treatment);

        BaseDto<TreatmentDto> Delete(TreatmentDto treatment);
    }

    public class TreatmentService : ITreatmentService
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;

        public TreatmentService(IDatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public BaseDto<TreatmentDto> Add(TreatmentDto treatment)
        {
            if (treatment == null) return BaseDto<TreatmentDto>.FailureResult("The Treatment data is null!");

            context.Treatments.Add(mapper.Map<Treatment>(treatment));
            if (context.SaveChanges() > 0) return BaseDto<TreatmentDto>.SuccessResult(treatment, "Treatment Added successfully.");

            return BaseDto<TreatmentDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public BaseDto<TreatmentDto> Delete(TreatmentDto treatment)
        {
            if (treatment is null) return BaseDto<TreatmentDto>.FailureResult("The Treatment data is null!");

            var result = context.Treatments.FirstOrDefault(c => c.Id == treatment.Id);
            if (result == null) return BaseDto<TreatmentDto>.FailureResult("The Treatment not find!");

            context.Treatments.Remove(result);
            if (context.SaveChanges() > 0) return BaseDto<TreatmentDto>.SuccessResult(treatment, "Treatment Deleted successfully.");

            return BaseDto<TreatmentDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public List<TreatmentDto> GetList()
        {
            return mapper.Map<List<TreatmentDto>>(context.Treatments.OrderBy(c => c.Name).ToList());
        }

        public BaseDto<TreatmentDto> Update(TreatmentDto treatment)
        {
            if (treatment == null) return BaseDto<TreatmentDto>.FailureResult("The Treatment data is null!");

            var treatmentForUpdate = context.Treatments.Find(treatment.Id);
            if (treatmentForUpdate is null) return BaseDto<TreatmentDto>.FailureResult("The Treatment not find!");

            if (treatment.Logo == "") treatment.Logo = treatmentForUpdate.Logo;
            mapper.Map(treatment, treatmentForUpdate);
            if (context.SaveChanges() > 0) return BaseDto<TreatmentDto>.SuccessResult(treatment, "Treatment Updated successfully.");

            return BaseDto<TreatmentDto>.FailureResult("Operation Failed! Please try another time!");
        }
    }

    public class TreatmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
