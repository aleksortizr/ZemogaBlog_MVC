using AutoMapper;
using Blog.DataAccess;
using Blog_Common.DTOs;

namespace Blog_Repositories
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CommentDTO>().ReverseMap();

            CreateMap<Post, PostDTO>()
                .ForMember(pts => pts.Comments, opt => opt.MapFrom(ps => ps.Comments))
            .AfterMap((src, dest) =>
            {
                dest.Author = src.User != null ? src.User.UserName : string.Empty;
            }).ReverseMap();



            CreateMap<User, UserDTO>()
                .AfterMap((src, dest) =>
            {
                dest.Role = src.Role != null ? src.Role.RoleName : string.Empty;
            }).ReverseMap();
        }
    }
}
