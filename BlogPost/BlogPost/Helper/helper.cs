

using AutoMapper;
using BlogPost.Dto;
using BlogPost.Models;

namespace BlogPost.Helper
{
    public class helper :Profile
    {
      public helper() 
        { 
            CreateMap<Tag,tagDto>().ReverseMap();
            CreateMap<tagDto,tagDto>();
            CreateMap<Blogpost, PostDto>();
            CreateMap<PostDto, Blogpost>();

        }
        
        
    }
}
