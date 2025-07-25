using AutoMapper;
using Rehab.Application.Accreditations;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Domain.Accreditations;
using Rehab.Domain.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Conditions
{
    public interface IConditionService
    {
        BaseDto<ConditionDto> Add(ConditionDto condition);
        List<ConditionDto> GetList();
        BaseDto<ConditionDto> Update(ConditionDto condition);

        BaseDto<ConditionDto> Delete(ConditionDto condition);
    }

    public class ConditionService: IConditionService
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;
        public ConditionService(IDatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public BaseDto<ConditionDto> Add(ConditionDto condition)
        {
            if (condition == null) return BaseDto<ConditionDto>.FailureResult("The Condition data is null!");

            context.Conditions.Add(mapper.Map<Condition>(condition));
            if (context.SaveChanges() > 0) return BaseDto<ConditionDto>.SuccessResult(condition, "Condition Added successfully.");

            return BaseDto<ConditionDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public BaseDto<ConditionDto> Delete(ConditionDto condition)
        {
            if (condition is null) return BaseDto<ConditionDto>.FailureResult("The Condition data is null!");

            var result = context.Conditions.FirstOrDefault(c => c.Id == condition.Id);
            if (result == null) return BaseDto<ConditionDto>.FailureResult("The Condition not find!");

            context.Conditions.Remove(result);
            if (context.SaveChanges() > 0) return BaseDto<ConditionDto>.SuccessResult(condition, "Condition Deleted successfully.");

            return BaseDto<ConditionDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public List<ConditionDto> GetList()
        {
            return mapper.Map<List<ConditionDto>>(context.Conditions.OrderBy(c => c.Name).ToList());
        }

        public BaseDto<ConditionDto> Update(ConditionDto condition)
        {
            if (condition == null) return BaseDto<ConditionDto>.FailureResult("The Condition data is null!");

            var conditionForUpdate = context.Conditions.Find(condition.Id);
            if (conditionForUpdate is null) return BaseDto<ConditionDto>.FailureResult("The Condition not find!");

            if (condition.Logo == "") condition.Logo = conditionForUpdate.Logo;
            mapper.Map(condition, conditionForUpdate);
            if (context.SaveChanges() > 0) return BaseDto<ConditionDto>.SuccessResult(condition, "Condition Updated successfully.");

            return BaseDto<ConditionDto>.FailureResult("Operation Failed! Please try another time!");
        }
    }

    public class ConditionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
