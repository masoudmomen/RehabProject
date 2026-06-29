using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Domain.SeoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Seo
{
    public interface ISeoService
    {
        BaseDto<MetaDto> Add(MetaDto metaDto);
        MetaDto? GetMeta(string PageName);
    }

    public class SeoService : ISeoService
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;
        public SeoService(IDatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public BaseDto<MetaDto> Add(MetaDto metaDto)
        {
            if (metaDto == null) return BaseDto<MetaDto>.FailureResult("There is not any keyword or description to save!");
            var meta = context.MetaContents.FirstOrDefault(c => c.PageName == metaDto.PageName);
            if (meta != null)
            {
                //meta = mapper.Map<MetaContent>(metaDto);
                meta.Keywords = metaDto.Keywords;
                meta.Description = metaDto.Description;
            }
            else
            {
                context.MetaContents.Add(mapper.Map<MetaContent>(metaDto));
            }
            if (context.SaveChanges() > 0)
            {
                return new BaseDto<MetaDto>()
                {
                    Data = metaDto,
                    Message = "Data Added Successfully",
                    Status = "success",
                    Success = true
                };
            }
            return new BaseDto<MetaDto>()
            {
                Data = metaDto,
                Message = "Operation Failed Please Try again!",
                Status = "danger",
                Success = false
            };
        }

        public MetaDto? GetMeta(string PageName)
        {
            var meta = context.MetaContents.FirstOrDefault(c => c.PageName == PageName);
            return mapper.Map<MetaDto?>(meta);
        }
    }
}
