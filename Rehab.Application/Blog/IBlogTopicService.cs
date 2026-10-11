using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Domain.Blog;

namespace Rehab.Application.Blog
{
    public interface IBlogTopicService
    {
        BaseDto<BlogTopicDto> Add(BlogTopicDto blogTopicDto);
        List<BlogTopicDto> GetList();
        BlogTopicFilterDto GetFilterTopics(int visibleCount);
        BaseDto<BlogTopicDto> Update(BlogTopicDto blogTopicDto);
        BaseDto<BlogTopicDto> Delete(BlogTopicDto blogTopicDto);
        Task<BaseDto<BlogTopicDto>> GetTopicBySlugAsync(string tagSlug);
    }

    public class BlogTopicService:IBlogTopicService
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;
        public BlogTopicService(IDatabaseContext context,IMapper mapper,IServiceScopeFactory scopeFactory )
        {
           _context = context;
            _mapper = mapper;
            _scopeFactory = scopeFactory;
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
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<IDatabaseContext>();

            return _mapper
                .Map<List<BlogTopicDto>>(context
                    .BlogPostTopics
                    .OrderBy(t => t.Name)
                    .ToList());
        }

        // Blog filter bar: the visibleCount topics with the most published posts become chips,
        // the rest go into "More topics" (A to Z).
        public BlogTopicFilterDto GetFilterTopics(int visibleCount)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<IDatabaseContext>();

            var now = DateTime.UtcNow;
            var topics = context.BlogPostTopics
                .AsNoTracking()
                .Select(t => new BlogTopicFilterItemDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Slug = t.Slug,
                    PostCount = t.Posts!.Count(p => !p.IsDeleted && p.IsActive && p.PublisheDate <= now)
                })
                .ToList();

            return SplitFilterTopics(topics, visibleCount);
        }

        public static BlogTopicFilterDto SplitFilterTopics(IEnumerable<BlogTopicFilterItemDto> topics, int visibleCount)
        {
            var byPopularity = topics
                .OrderByDescending(t => t.PostCount)
                .ThenBy(t => t.Name, StringComparer.OrdinalIgnoreCase)
                .ThenBy(t => t.Id)
                .ToList();

            var take = Math.Max(visibleCount, 0);
            return new BlogTopicFilterDto
            {
                Visible = byPopularity.Take(take).ToList(),
                Hidden = byPopularity.Skip(take)
                    .OrderBy(t => t.Name, StringComparer.OrdinalIgnoreCase)
                    .ThenBy(t => t.Id)
                    .ToList()
            };
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
        public async Task<BaseDto<BlogTopicDto>> GetTopicBySlugAsync(string tagSlug)
        {
            var result = await _context.BlogPostTopics
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Slug == tagSlug);
            var resultDto = _mapper.Map<BlogTopicDto>(result);
            if (result == null) return BaseDto<BlogTopicDto>.FailureResult("The Topic not find!");
            return BaseDto<BlogTopicDto>.SuccessResult(resultDto, "OK");
        }
    }
   
    public class BlogTopicDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;

        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class BlogTopicFilterItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public int PostCount { get; set; }
    }

    public class BlogTopicFilterDto
    {
        public List<BlogTopicFilterItemDto> Visible { get; set; } = new();
        public List<BlogTopicFilterItemDto> Hidden { get; set; } = new();
    }
}
