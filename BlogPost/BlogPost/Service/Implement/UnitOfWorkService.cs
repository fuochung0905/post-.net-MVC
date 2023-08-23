using BlogPost.DataContext;

namespace BlogPost.Service.Implement
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly BlogpostContext _blogpostContext;
        private PostService _postService;
        private TagService _tagService;
        public UnitOfWorkService(BlogpostContext context)
        {
            _blogpostContext = context;
        }
        public PostInterface Post
        {
            get
            {
                return _postService=_postService ??new PostService(_blogpostContext);
            }
            
        }
        public TagInterface Tag
        {
            get
            {
                return _tagService=_tagService ?? new TagService(_blogpostContext); 
            }
        }
      

        public void Save()
        {
           _blogpostContext.SaveChanges();
        }
    }
}
