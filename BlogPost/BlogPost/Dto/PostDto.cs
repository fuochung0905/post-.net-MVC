using BlogPost.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogPost.Dto
{
    public class PostDto
    {
        public int Id { get; set; }

        public string Heading { get; set; }

        public string Pagetitle { get; set; } 

        public string Content { get; set; } 

        public string Shortdescription { get; set; } 

        public string Featuredimage { get; set; } 

        public string Urlhandle { get; set; } 

        public DateTime? Publisheddate { get; set; }

        public string? Author { get; set; }

        public bool? Visible { get; set; }

        
       

    }
}
