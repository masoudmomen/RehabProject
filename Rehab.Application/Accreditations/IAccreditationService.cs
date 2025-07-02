using AutoMapper;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Domain.Accreditations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Accreditations
{
    public interface IAccreditationService
    {
        BaseDto<AccreditationDto> Add(AccreditationDto accreditation);
        List<AccreditationDto> GetList();
        BaseDto<AccreditationDto> Update(AccreditationDto accreditation);

        BaseDto<AccreditationDto> Delete(AccreditationDto accreditation);
    }

    public class AccreditationService : IAccreditationService
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;

        public AccreditationService(IDatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public BaseDto<AccreditationDto> Add(AccreditationDto accreditation)
        {
            if (accreditation == null) return BaseDto<AccreditationDto>.FailureResult("The Accreditation data is null!");

            context.Accreditations.Add(mapper.Map<Accreditation>(accreditation));
            if (context.SaveChanges() > 0) return BaseDto<AccreditationDto>.SuccessResult(accreditation, "Accreditation Added successfully.");

            return BaseDto<AccreditationDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public BaseDto<AccreditationDto> Delete(AccreditationDto accreditation)
        {
            if (accreditation is null) return BaseDto<AccreditationDto>.FailureResult("The Accreditation data is null!");

            var result = context.Accreditations.FirstOrDefault(c => c.Id == accreditation.Id);
            if (result == null) return BaseDto<AccreditationDto>.FailureResult("The Accreditation not find!");

            context.Accreditations.Remove(result);
            if (context.SaveChanges() > 0) return BaseDto<AccreditationDto>.SuccessResult(accreditation, "Accreditation Deleted successfully.");

            return BaseDto<AccreditationDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public List<AccreditationDto> GetList()
        {
            return mapper.Map<List<AccreditationDto>>(context.Accreditations.OrderBy(c=>c.Name).ToList());
        }

        public BaseDto<AccreditationDto> Update(AccreditationDto accreditation)
        {
            if (accreditation == null) return BaseDto<AccreditationDto>.FailureResult("The Accreditation data is null!");

            var accreditationForUpdate = context.Accreditations.Find(accreditation.Id);
            if (accreditationForUpdate is null) return BaseDto<AccreditationDto>.FailureResult("The Accreditation not find!");

            if (accreditation.Logo == "") accreditation.Logo = accreditationForUpdate.Logo;
            mapper.Map(accreditation, accreditationForUpdate);
            if (context.SaveChanges() > 0) return BaseDto<AccreditationDto>.SuccessResult(accreditation, "Accreditation Updated successfully.");

            return BaseDto<AccreditationDto>.FailureResult("Operation Failed! Please try another time!");
        }
    }

    public class AccreditationDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

