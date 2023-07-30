using AutoMapper;
using LDHBlog.Model;
using LDHBlog.Model.DTO;
using LDHBlog.Service;

namespace LDHBlog.WebApi.Utility.AutoMapper
{
    public class CustomAutoMapperProfile :Profile
    {
        public CustomAutoMapperProfile()
        {
            base.CreateMap<WriterInfo, WriterInfoDto>();
            base.CreateMap<BlogNews, BlogNewsDto>()
                .ForMember(dest => dest.TypeName, sourse => sourse.MapFrom(src => src.TypeInfo.Name))
                .ForMember(dest => dest.WriterName, sourse => sourse.MapFrom(src => src.WriterInfo.Name));
        }

    }
}
