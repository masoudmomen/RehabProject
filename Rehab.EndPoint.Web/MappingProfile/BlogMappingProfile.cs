using AutoMapper;
using Rehab.Application.Blog;
using Rehab.Domain.Blog;
using Rehab.EndPoint.Web.ViewModels;
namespace Rehab.EndPoint.Web.MappingProfile
{
    public class BlogMappingProfile:Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<FeaturedBlogPostDto, BlogFeaturedArticleViewModel>()
                .ForMember(dest => dest.ImageUrl,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrWhiteSpace(src.ImageUrl)
                            ? "https://placehold.co/700x600"
                            : src.ImageUrl))
                .ForMember(dest => dest.PublishedDate,
                    opt => opt.MapFrom(src => src.PublisheDate.ToString("MMMM d, yyyy")))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(_ => "John Doe"))
                .ForMember(dest => dest.AuthorRole, opt => opt.MapFrom(_ => "Rehab Navigator Copy writer"))
                .ForMember(dest => dest.AuthorInitials, opt => opt.MapFrom(_ => "JD"));
            CreateMap<BlogPostCardDto, BlogPostCardViewModel>()
            .ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom(src =>
                    string.IsNullOrWhiteSpace(src.ImageUrl)
                        ? "https://placehold.co/400x260"
                        : src.ImageUrl))
            .ForMember(dest => dest.PublisheDate,
                opt => opt.MapFrom(src => src.PublisheDate))
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(_ => "Rehab Navigator"))
            .ForMember(dest => dest.AuthorRole, opt => opt.MapFrom(_ => "Rehab Navigator Copy writer"))
            .ForMember(dest => dest.AuthorInitials, opt => opt.MapFrom(_ => "RN"));

            CreateMap<BlogPostDto, BlogPostCardViewModel>();
            CreateMap<BlogPostDetailDto, BlogPostDetailViewModel>();
            CreateMap<BlogTopicDto, TopicViewModel>();
           //.ForMember(d => d.ReadTimeDisplay, o => o.MapFrom(s => $"{s.TimeToRead} min read"))
           //.ForMember(d => d.PublishedDisplay, o => o.MapFrom(s => s.PublisheDate.ToString("MMM d")));
        }
    }
         
    }
 
 
