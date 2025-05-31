using AutoMapper;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Domain.LevelsOfCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.LevelsOfCare
{
    public interface ILevelsOfCareService
    {
        BaseDto<LevelsOfCareDto> Add(LevelsOfCareDto loc);
        List<LevelsOfCareDto> GetList();
        BaseDto<LevelsOfCareDto> Update(LevelsOfCareDto loc);

        BaseDto<LevelsOfCareDto> Delete(LevelsOfCareDto loc);
    }

    public class LevelsOfCareService : ILevelsOfCareService
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;

        public LevelsOfCareService(IDatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public BaseDto<LevelsOfCareDto> Add(LevelsOfCareDto loc)
        {
            if (loc == null) return BaseDto<LevelsOfCareDto>.FailureResult("The LOC data is null!");

            context.Locs.Add(mapper.Map<Loc>(loc));
            if (context.SaveChanges() > 0) return BaseDto<LevelsOfCareDto>.SuccessResult(loc, "LOC Added successfully.");

            return BaseDto<LevelsOfCareDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public BaseDto<LevelsOfCareDto> Delete(LevelsOfCareDto loc)
        {
            if (loc is null) return BaseDto<LevelsOfCareDto>.FailureResult("The LOC data is null!");

            var result = context.Locs.FirstOrDefault(c => c.Id == loc.Id);
            if (result == null) return BaseDto<LevelsOfCareDto>.FailureResult("The LOC not find!");

            context.Locs.Remove(result);
            if (context.SaveChanges() > 0) return BaseDto<LevelsOfCareDto>.SuccessResult(loc, "LOC Deleted successfully.");

            return BaseDto<LevelsOfCareDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public List<LevelsOfCareDto> GetList()
        {
            return mapper.Map<List<LevelsOfCareDto>>(context.Locs.ToList());
        }

        public BaseDto<LevelsOfCareDto> Update(LevelsOfCareDto loc)
        {
            if (loc == null) return BaseDto<LevelsOfCareDto>.FailureResult("The LOC data is null!");

            var locForUpdate = context.Locs.Find(loc.Id);
            if (locForUpdate is null) return BaseDto<LevelsOfCareDto>.FailureResult("The LOC not find!");

            if (loc.Logo == "") loc.Logo = locForUpdate.Logo;
            mapper.Map(loc, locForUpdate);
            if (context.SaveChanges() > 0) return BaseDto<LevelsOfCareDto>.SuccessResult(loc, "LOC Updated successfully.");

            return BaseDto<LevelsOfCareDto>.FailureResult("Operation Failed! Please try another time!");
        }
    }

    public class LevelsOfCareDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
