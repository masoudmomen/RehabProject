using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Domain.Blog;

namespace Rehab.Application.Blog
{
    public interface IBlogTagService
    {
        BaseDto<BlogTagDto> Add(BlogTagDto BlogTagDto);
        List<BlogTagDto> GetList();
        BaseDto<BlogTagDto> Update(BlogTagDto BlogTagDto);
        BaseDto<BlogTagDto> Delete(BlogTagDto BlogTagDto);
        Task<List<BlogTagDto>> GetSuggestedTagsAsync(string name);
    }

    public class BlogTagService:IBlogTagService
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;

        public BlogTagService(IDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BaseDto<BlogTagDto> Add(BlogTagDto BlogTag)
        {
            if (BlogTag == null) return BaseDto<BlogTagDto>.FailureResult("The Topc data is null!");

            _context.BlogPostTags.Add(_mapper.Map<BlogPostTag>(BlogTag));
            if (_context.SaveChanges() > 0) return BaseDto<BlogTagDto>.SuccessResult(BlogTag, "Tag Added successfully.");

            return BaseDto<BlogTagDto>.FailureResult("Operation Failed! Please try another time!");

        }
        public List<BlogTagDto> GetList()
        {
            return _mapper
                .Map<List<BlogTagDto>>(_context
                    .BlogPostTags
                    .OrderBy(t => t.Name)
                    .ToList());
        }
        public BaseDto<BlogTagDto> Update(BlogTagDto BlogTag)
        {
            if (BlogTag == null) return BaseDto<BlogTagDto>.FailureResult("The Tag data is null!");
            var BlogTagForUpdate = _context.BlogPostTags.Find(BlogTag.Id);
            if (BlogTagForUpdate is null) return BaseDto<BlogTagDto>.FailureResult("The Tag not find!");

            if (BlogTag.Logo == "") BlogTag.Logo = BlogTagForUpdate.Logo;
            _mapper.Map(BlogTag, BlogTagForUpdate);
            if (_context.SaveChanges() > 0) return BaseDto<BlogTagDto>.SuccessResult(BlogTag, "Tag Updated successfully.");

            return BaseDto<BlogTagDto>.FailureResult("Operation Failed! Please try another time!");
        }
        public BaseDto<BlogTagDto> Delete(BlogTagDto BlogTag)
        {
            if (BlogTag is null) return BaseDto<BlogTagDto>.FailureResult("The Tag data is null!");

            var result = _context.BlogPostTags.FirstOrDefault(c => c.Id == BlogTag.Id);
            if (result == null) return BaseDto<BlogTagDto>.FailureResult("The Tag not find!");

            _context.BlogPostTags.Remove(result);
            if (_context.SaveChanges() > 0) return BaseDto<BlogTagDto>.SuccessResult(BlogTag, "The Tag Deleted successfully.");

            return BaseDto<BlogTagDto>.FailureResult("Operation Failed! Please try another time!");
        }
      
        //Show Suggested Tag when user is typing...
        public async Task<List<BlogTagDto>> GetSuggestedTagsAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return new List<BlogTagDto>();

            var tags = await _context.BlogPostTags.Where(t => t.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<BlogTagDto>>(tags);
        }



    }

    
    public class BlogTagDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
