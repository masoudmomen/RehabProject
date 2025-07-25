using AutoMapper;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Domain.SubstancesWeTreat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.SubstancesWeTreat
{
    public interface ISubstancesWeTreatService
    {
        BaseDto<SwtDto> Add(SwtDto swt);
        List<SwtDto> GetList();
        BaseDto<SwtDto> Update(SwtDto swt);

        BaseDto<SwtDto> Delete(SwtDto swt);
    }

    public class SwtService : ISubstancesWeTreatService
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;

        public SwtService(IDatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public BaseDto<SwtDto> Add(SwtDto swt)
        {
            if (swt == null) return BaseDto<SwtDto>.FailureResult("The Swt data is null!");

            context.Swts.Add(mapper.Map<Swt>(swt));
            if (context.SaveChanges() > 0) return BaseDto<SwtDto>.SuccessResult(swt, "Swt Added successfully.");

            return BaseDto<SwtDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public BaseDto<SwtDto> Delete(SwtDto swt)
        {
            if (swt is null) return BaseDto<SwtDto>.FailureResult("The Swt data is null!");

            var result = context.Swts.FirstOrDefault(c => c.Id == swt.Id);
            if (result == null) return BaseDto<SwtDto>.FailureResult("The Swt not find!");

            context.Swts.Remove(result);
            if (context.SaveChanges() > 0) return BaseDto<SwtDto>.SuccessResult(swt, "Swt Deleted successfully.");

            return BaseDto<SwtDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public List<SwtDto> GetList()
        {
            return mapper.Map<List<SwtDto>>(context.Swts.OrderBy(c => c.Name).ToList());
        }

        public BaseDto<SwtDto> Update(SwtDto swt)
        {
            if (swt == null) return BaseDto<SwtDto>.FailureResult("The Swt data is null!");

            var swtForUpdate = context.Swts.Find(swt.Id);
            if (swtForUpdate is null) return BaseDto<SwtDto>.FailureResult("The Swt not find!");

            if (swt.Logo == "") swt.Logo = swtForUpdate.Logo;
            mapper.Map(swt, swtForUpdate);
            if (context.SaveChanges() > 0) return BaseDto<SwtDto>.SuccessResult(swt, "Swt Updated successfully.");

            return BaseDto<SwtDto>.FailureResult("Operation Failed! Please try another time!");
        }
    }

    public class SwtDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
