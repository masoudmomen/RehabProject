using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rehab.Application.Amenities;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Domain.Amenities;
using Rehab.Domain.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Rehab.Application.Tags
{
    public interface ITagService
    {
        BaseDto<TagDto> Add(TagDto tag);
        BaseDto<TagDto> Update(TagDto tag);
        BaseDto<TagDto> Delete(TagDto tag);
        List<TagDto> Getlist();
        
        Task<List<TagDto>> GetTagsByNameAsync(string tagName);
    }
    public class TagService : ITagService
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        public TagService(IDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public BaseDto<TagDto> Add(TagDto tag)
        {
            if (tag == null) return BaseDto<TagDto>.FailureResult("The Tag data is null!");

            _context.Tags.Add(_mapper.Map<Tag>(tag));
            if (_context.SaveChanges() > 0)
                return BaseDto<TagDto>.SuccessResult(tag, "Tag created successfully!");

            return BaseDto<TagDto>.FailureResult("Operation Faild! please try another time!");
        }
        public BaseDto<TagDto> Delete(TagDto tag)
        {
            if (tag == null) return BaseDto<TagDto>.FailureResult("The Tag data is null!");

            var result = _context.Tags.FirstOrDefault(Tags => Tags.Id == tag.Id);
            if (result == null) return BaseDto<TagDto>.FailureResult("The Tag not find!");
    
            _context.Tags.Remove(result);
            if (_context.SaveChanges() > 0) return BaseDto<TagDto>.SuccessResult(tag, "Tag is deleted successfully!");

            return BaseDto<TagDto>.FailureResult("Operation failed! Pleas try another time!");
        }

        public List<TagDto> Getlist()
        {
            return _mapper.Map<List<TagDto>>(_context.Tags.OrderBy(t => t.Name).ToList());
        }

        public BaseDto<TagDto> Update(TagDto tag)
        {
            if (tag == null) return BaseDto<TagDto>.FailureResult("The Tag data is null!");

            var tagForUpdate = _context.Amenities.Find(tag.Id);
            if (tagForUpdate is null) return BaseDto<TagDto>.FailureResult("The Tag not find!");

            
            _mapper.Map(tag, tagForUpdate);
            if (_context.SaveChanges() > 0) return BaseDto<TagDto>.SuccessResult(tag, "Tag is updated successfully.");

            return BaseDto<TagDto>.FailureResult("Operation Failed! Please try another time!");

        }

      public async Task<List<TagDto>> GetTagsByNameAsync(string tagName)
        {
            if (string.IsNullOrEmpty(tagName)) return new List<TagDto>();
            var tags = await _context.Tags.Where(t => t.Name.Contains(tagName)).ToListAsync();
            //var tags =await _context.Tags.ToListAsync();
            return _mapper.Map<List<TagDto>>(tags);
        }
    }
    public class TagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
