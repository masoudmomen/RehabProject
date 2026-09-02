using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Application.Dtos;
using Rehab.Application.Tags;
using Rehab.Domain.Blog;
using System;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using static Rehab.Application.Blog.BlogService;
namespace Rehab.Application.Blog
{
    public interface IBlogPostService
    {
        Task<BaseDto<BlogPostDto>> AddPost(BlogPostDto blog);
        Task<PaginatedItemDto<BlogPostDto>> GetPostsAsync(int page, int pageSize);
        Task<BaseDto<BlogPostDto>> GetPostByIdAsync(int id);
        Task<BaseDto<BlogPostDto>> UpdatePostAsync(BlogPostDto postDto);
        Task<BaseDto<bool>> DeletePostAsync(int id);
        Task<BaseDto<FeaturedBlogPostDto>> GetLatestFeaturedPostAsync();
        //Task<string> GenerateUniqueSlugAsync(string title, int? excludedId = null);
        Task<BaseDto<List<BlogPostCardDto>>> GetRecentPostsAsync(int count = 3);
        Task<BaseDto<BlogPostDetailDto>> GetPostDetailBySlugAsync(string slug);
        Task<BaseDto<List<BlogPostCardDto>>> GetRelatedPostsAsync(int postId, int take = 4);
        Task<PaginatedItemDto<BlogPostCardDto>> GetPostsAsync(int page, int pageSize, BlogPostFilter? filter);
    }


    public class BlogService : IBlogPostService
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;

        public BlogService(IDatabaseContext context,
            IMapper mapper, IServiceScopeFactory scopeFactory)
        {
            _context = context;
            _mapper = mapper;
            _scopeFactory = scopeFactory;
        }

        public async Task<BaseDto<BlogPostDto>> AddPost(BlogPostDto postDto)
        {
            if (postDto == null) return BaseDto<BlogPostDto>.FailureResult("Post data is null!");
            var post = _mapper.Map<BlogPost>(postDto);

            if (postDto.TopicsId != null && postDto.TopicsId.Any())
            {
                var topics = await _context.BlogPostTopics
                    .Where(t => postDto.TopicsId.Contains(t.Id))
                    .ToListAsync();

                post.Topics = topics;
            }

            if (postDto.TagList != null && postDto.TagList.Any())
            {
                var tagNames = postDto.TagList?
               .Select(t => t.Name)
               .Where(name => !string.IsNullOrWhiteSpace(name))
               .ToList() ?? new List<string>();

                var tags = await GetOrCreateTags(tagNames);
                post.Tags = tags;
            }

            _context.BlogPosts.Add(post);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                var resultDto = _mapper.Map<BlogPostDto>(post);
                return BaseDto<BlogPostDto>.SuccessResult(resultDto, "Post Added Successfully.");
            }

            return BaseDto<BlogPostDto>.FailureResult("Operation Failed! Please try another time!");
        }

        // Handle Tags : If Tags exist returns and if they don't exist create them
        private async Task<List<BlogPostTag>> GetOrCreateTags(List<string> tagNames)
        {
            var normalizedTagNames = tagNames
                .Select(t => t.Trim().ToLower())
                .Distinct()
                .ToList();

            var existingTags = await _context.BlogPostTags
                .Where(t => normalizedTagNames.Contains(t.Name))
                .ToListAsync();

            var existingTagNames = existingTags.Select(t => t.Name).ToHashSet();
            var newTagNames = normalizedTagNames.Where(t => !existingTagNames.Contains(t.ToLower())).ToList();
            var newTags = newTagNames.Select(name => new BlogPostTag { Name = name }).ToList();

            _context.BlogPostTags.AddRange(newTags);
            return existingTags.Concat(newTags).ToList();
        }

        //Get Posts List
        public async Task<PaginatedItemDto<BlogPostDto>> GetPostsAsync(int page, int pageSize)
        {
            var query = _context.BlogPosts
                .AsNoTracking()
                .Where(p => !p.IsDeleted);

            var rowCount = await query.CountAsync();

            var data = await query
                .OrderByDescending(p => p.PublisheDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<BlogPostDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PaginatedItemDto<BlogPostDto>(
                page,
                pageSize,
                rowCount,
                data
            );
        }

        public async Task<BaseDto<BlogPostDto>> GetPostByIdAsync(int id)
        {
            var post = await _context.BlogPosts
                .AsNoTracking()
                .Where(p => !p.IsDeleted && p.Id == id)
                .ProjectTo<BlogPostDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            if (post == null)
                return BaseDto<BlogPostDto>.FailureResult("Post not found.");
            return BaseDto<BlogPostDto>.SuccessResult(post, "OK");
        }
        public async Task<BaseDto<BlogPostDto>> UpdatePostAsync(BlogPostDto postDto)
        {
            if (postDto == null) return BaseDto<BlogPostDto>.FailureResult("Post data is null!");
            if (postDto.Id <= 0) return BaseDto<BlogPostDto>.FailureResult("Invalid post id.");

            var post = await _context.BlogPosts
                .Include(p => p.Tags)
                .Include(p => p.Topics)
                .FirstOrDefaultAsync(p => !p.IsDeleted && p.Id == postDto.Id);

            if (post == null)
                return BaseDto<BlogPostDto>.FailureResult("Post not found.");

            _mapper.Map(postDto, post);

            if (postDto.TopicsId != null)
            {
                var topics = postDto.TopicsId.Any()
                    ? await _context.BlogPostTopics.Where(t => postDto.TopicsId.Contains(t.Id)).ToListAsync()
                    : new List<BlogPostTopic>();
                post.Topics = topics;
            }

            if (postDto.TagsId != null)
            {
                var tags = postDto.TagsId.Any()
                    ? await _context.BlogPostTags.Where(t => postDto.TagsId.Contains(t.Id)).ToListAsync()
                    : new List<BlogPostTag>();
                post.Tags = tags;
            }
            else if (postDto.TagList != null)
            {
                var tagNames = postDto.TagList
                    .Select(t => t.Name)
                    .Where(name => !string.IsNullOrWhiteSpace(name))
                    .ToList();

                var tags = tagNames.Any()
                    ? await GetOrCreateTags(tagNames)
                    : new List<BlogPostTag>();

                post.Tags = tags;
            }

            await _context.SaveChangesAsync();

            var resultDto = _mapper.Map<BlogPostDto>(post);
            return BaseDto<BlogPostDto>.SuccessResult(resultDto, "Post Updated Successfully.");
        }
        public async Task<BaseDto<bool>> DeletePostAsync(int id)
        {
            if (id <= 0)
                return BaseDto<bool>.FailureResult("Invalid post id.");

            var post = await _context.BlogPosts.FirstOrDefaultAsync(p => p.Id == id);

            if (post == null || post.IsDeleted)
                return BaseDto<bool>.FailureResult("Post not found.");

            post.IsDeleted = true;
            await _context.SaveChangesAsync();

            return BaseDto<bool>.SuccessResult(true, "Post deleted successfully.");
        }
        public async Task<BaseDto<FeaturedBlogPostDto>> GetLatestFeaturedPostAsync()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<IDatabaseContext>();

            var post = await context.BlogPosts
        .AsNoTracking()
        .Where(p => !p.IsDeleted && p.IsActive && p.IsFeatured)
        .OrderByDescending(p => p.PublisheDate)
        .ProjectTo<FeaturedBlogPostDto>(_mapper.ConfigurationProvider)
        .FirstOrDefaultAsync();

            if (post == null)
                return BaseDto<FeaturedBlogPostDto>.FailureResult("No featured article found.");
            var resultDto = _mapper.Map<FeaturedBlogPostDto>(post);
            return BaseDto<FeaturedBlogPostDto>.SuccessResult(resultDto, "OK");
        }
        public async Task<BaseDto<List<BlogPostCardDto>>> GetRecentPostsAsync(int count = 3)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<IDatabaseContext>();

            var posts = await context.BlogPosts
                .AsNoTracking()
                .Where(p => !p.IsDeleted && p.IsActive && !p.IsFeatured)
                .OrderByDescending(p => p.PublisheDate)
                .Take(count)
                .ProjectTo<BlogPostCardDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (posts == null || posts.Count == 0)
                return BaseDto<List<BlogPostCardDto>>.FailureResult("No recent posts found.");

            return BaseDto<List<BlogPostCardDto>>.SuccessResult(posts, "OK");
        }
        public async Task<BaseDto<BlogPostDetailDto>> GetPostDetailBySlugAsync(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
                return null;

            var post = await _context.BlogPosts
                .AsNoTracking()
                .Where(p => !p.IsDeleted && p.Slug == slug)
                .ProjectTo<BlogPostDetailDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (post == null)
                return BaseDto<BlogPostDetailDto>.FailureResult("Post not found.");
            return BaseDto<BlogPostDetailDto>.SuccessResult(post, "OK");

        }
        public async Task<BaseDto<List<BlogPostCardDto>>> GetRelatedPostsAsync(int postId, int take = 4)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<IDatabaseContext>();

            var topicIds = await context.BlogPosts
                .AsNoTracking()
                .Where(p => p.Id == postId)
                .SelectMany(p => p.Topics.Select(t => t.Id))
                .ToListAsync();

            if (topicIds.Count == 0)
                return new BaseDto<List<BlogPostCardDto>>();

            var posts = await _context.BlogPosts
                .AsNoTracking()
                .Where(p => p.Id != postId
                            && !p.IsDeleted
                            && p.Topics.Any(t => topicIds.Contains(t.Id)))
                // rank by number of shared topics, then recency
                .OrderByDescending(p => p.Topics.Count(t => topicIds.Contains(t.Id)))
                .ThenByDescending(p => p.PublisheDate)
                .Take(take)
                .ProjectTo<BlogPostCardDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (posts == null || posts.Count == 0)
                return BaseDto<List<BlogPostCardDto>>.FailureResult("No recent posts found.");

            return BaseDto<List<BlogPostCardDto>>.SuccessResult(posts, "OK");

        }

        public async Task<PaginatedItemDto<BlogPostCardDto>> GetPostsAsync(int page, int pageSize, BlogPostFilter? filter)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<IDatabaseContext>();

            var query = context.BlogPosts
                .AsNoTracking()
                .Where(p => !p.IsDeleted && p.IsActive && !p.IsFeatured);

            if (filter is not null)
            {
                if (!string.IsNullOrWhiteSpace(filter.TagSlug))
                {
                    query = query.Where(p => p.Tags.Any(pt => pt.Slug == filter.TagSlug));
                }
                if (!string.IsNullOrWhiteSpace(filter.TopicSlug))
                {
                    query = query.Where(p => p.Topics.Any(pt => pt.Slug == filter.TopicSlug));
                }
                if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
                {
                    var term = filter.SearchTerm.Trim();
                    query = query.Where(p => p.Title.Contains(term) || p.Description!.Contains(term));
                }
            }

            query = query.OrderByDescending(p => p.PublisheDate);

            var count = await query.LongCountAsync();

            var data = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<BlogPostCardDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PaginatedItemDto<BlogPostCardDto>(page, pageSize, count, data);
        }






    }
}
