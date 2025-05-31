using AutoMapper;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Domain.Highlights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Highlights
{
    public interface IHighlightService
    {
        BaseDto<HighlightDto> Add(HighlightDto highlight);
        List<HighlightDto> GetList();
        BaseDto<HighlightDto> Update(HighlightDto highlight);

        BaseDto<HighlightDto> Delete(HighlightDto highlight);
    }
    public class HighlightService : IHighlightService
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;

        public HighlightService(IDatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public BaseDto<HighlightDto> Add(HighlightDto highlight)
        {
            if (highlight == null) return BaseDto<HighlightDto>.FailureResult("The Highlight data is null!");

            context.Highlights.Add(mapper.Map<Highlight>(highlight));
            if (context.SaveChanges() > 0) return BaseDto<HighlightDto>.SuccessResult(highlight, "Highlight Added successfully.");

            return BaseDto<HighlightDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public BaseDto<HighlightDto> Delete(HighlightDto highlight)
        {
            if (highlight is null) return BaseDto<HighlightDto>.FailureResult("The Highlight data is null!");

            var result = context.Highlights.FirstOrDefault(c => c.Id == highlight.Id);
            if (result == null) return BaseDto<HighlightDto>.FailureResult("The Highlight not find!");

            context.Highlights.Remove(result);
            if (context.SaveChanges() > 0) return BaseDto<HighlightDto>.SuccessResult(highlight, "Highlight Deleted successfully.");

            return BaseDto<HighlightDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public List<HighlightDto> GetList()
        {
            return mapper.Map<List<HighlightDto>>(context.Highlights.ToList());
        }

        public BaseDto<HighlightDto> Update(HighlightDto highlight)
        {
            if (highlight == null) return BaseDto<HighlightDto>.FailureResult("The Highlight data is null!");

            var highlightForUpdate = context.Highlights.Find(highlight.Id);
            if (highlightForUpdate is null) return BaseDto<HighlightDto>.FailureResult("The Highlight not find!");

            if (highlight.Logo == "") highlight.Logo = highlightForUpdate.Logo;
            mapper.Map(highlight, highlightForUpdate);
            if (context.SaveChanges() > 0) return BaseDto<HighlightDto>.SuccessResult(highlight, "Highlight Updated successfully.");

            return BaseDto<HighlightDto>.FailureResult("Operation Failed! Please try another time!");
        }
    }

    public class HighlightDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
