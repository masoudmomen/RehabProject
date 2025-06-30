using AutoMapper;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Domain.WhoWeTreat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.WhoWeTreat
{
    public interface IWwtService
    {
        BaseDto<WwtDto> Add(WwtDto wwt);
        List<WwtDto> GetList();
        BaseDto<WwtDto> Update(WwtDto wwt);

        BaseDto<WwtDto> Delete(WwtDto wwt);
    }

    public class WwtService : IWwtService
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;

        public WwtService(IDatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public BaseDto<WwtDto> Add(WwtDto wwt)
        {
            if (wwt == null) return BaseDto<WwtDto>.FailureResult("The WWT data is null!");

            context.Wwts.Add(mapper.Map<Wwt>(wwt));
            if (context.SaveChanges() > 0) return BaseDto<WwtDto>.SuccessResult(wwt, "WWT Added successfully.");

            return BaseDto<WwtDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public BaseDto<WwtDto> Delete(WwtDto wwt)
        {
            if (wwt is null) return BaseDto<WwtDto>.FailureResult("The WWT data is null!");

            var result = context.Wwts.FirstOrDefault(c => c.Id == wwt.Id);
            if (result == null) return BaseDto<WwtDto>.FailureResult("The WWT not find!");

            context.Wwts.Remove(result);
            if (context.SaveChanges() > 0) return BaseDto<WwtDto>.SuccessResult(wwt, "WWT Deleted successfully.");

            return BaseDto<WwtDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public List<WwtDto> GetList()
        {
            return mapper.Map<List<WwtDto>>(context.Wwts.OrderBy(c => c.Name).ToList());
        }

        public BaseDto<WwtDto> Update(WwtDto wwt)
        {
            if (wwt == null) return BaseDto<WwtDto>.FailureResult("The WWT data is null!");

            var wwtForUpdate = context.Wwts.Find(wwt.Id);
            if (wwtForUpdate is null) return BaseDto<WwtDto>.FailureResult("The WWT not find!");

            if (wwt.Logo == "") wwt.Logo = wwtForUpdate.Logo;
            mapper.Map(wwt, wwtForUpdate);
            if (context.SaveChanges() > 0) return BaseDto<WwtDto>.SuccessResult(wwt, "WWT Updated successfully.");

            return BaseDto<WwtDto>.FailureResult("Operation Failed! Please try another time!");
        }
    }

    public class WwtDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
