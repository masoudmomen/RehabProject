using AutoMapper;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Domain.Blog;

namespace Rehab.Application.Blog
{
    public interface IBlogTopicService
    {
        BaseDto<BlogTopicDto> Add(BlogTopicDto blogTopicDto);
        List<BlogTopicDto> GetList();
        BaseDto<BlogTopicDto> Update(BlogTopicDto blogTopicDto);
        BaseDto<BlogTopicDto> Delete(BlogTopicDto blogTopicDto);
    }

    public class BlogTopicService:IBlogTopicService
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;

        public BlogTopicService(IDatabaseContext context,IMapper mapper )
        {
           _context = context;
            _mapper = mapper;
        }
     
        public BaseDto<BlogTopicDto> Add(BlogTopicDto blogTopic)
        {
            if(blogTopic == null) return BaseDto<BlogTopicDto>.FailureResult("The Topc data is null!");

            _context.BlogPostTopics.Add(_mapper.Map<BlogPostTopic>(blogTopic));
            if (_context.SaveChanges() > 0) return BaseDto<BlogTopicDto>.SuccessResult(blogTopic, "Topic Added successfully.");

            return BaseDto<BlogTopicDto>.FailureResult("Operation Failed! Please try another time!");

        }
        public List<BlogTopicDto> GetList()
        {
            return _mapper
                .Map<List<BlogTopicDto>>(_context
                    .BlogPostTopics
                    .OrderBy(t => t.Name)
                    .ToList());
        }
        public BaseDto<BlogTopicDto> Update(BlogTopicDto blogTopic)
        {
            if (blogTopic == null) return BaseDto<BlogTopicDto>.FailureResult("The Topic data is null!");
            var blogTopicForUpdate = _context.BlogPostTopics.Find(blogTopic.Id);
            if (blogTopicForUpdate is null) return BaseDto<BlogTopicDto>.FailureResult("The Topic not find!");

            if (blogTopic.Logo == "") blogTopic.Logo = blogTopicForUpdate.Logo;
            _mapper.Map(blogTopic, blogTopicForUpdate);
            if (_context.SaveChanges() > 0) return BaseDto<BlogTopicDto>.SuccessResult(blogTopic, "Topic Updated successfully.");

            return BaseDto<BlogTopicDto>.FailureResult("Operation Failed! Please try another time!");
        }
        public BaseDto<BlogTopicDto> Delete(BlogTopicDto blogTopic)
        {
            if (blogTopic is null) return BaseDto<BlogTopicDto>.FailureResult("The Topic data is null!");

            var result = _context.BlogPostTopics.FirstOrDefault(c => c.Id == blogTopic.Id);
            if (result == null) return BaseDto<BlogTopicDto>.FailureResult("The Topic not find!");

            _context.BlogPostTopics.Remove(result);
            if (_context.SaveChanges() > 0) return BaseDto<BlogTopicDto>.SuccessResult(blogTopic, "The Topic Deleted successfully.");

            return BaseDto<BlogTopicDto>.FailureResult("Operation Failed! Please try another time!");
        }
    }
   
    public class BlogTopicDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
