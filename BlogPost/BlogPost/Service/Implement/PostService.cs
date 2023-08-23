using BlogPost.DataContext;
using BlogPost.Models;

namespace BlogPost.Service.Implement
{
    public class PostService : PostInterface
    {
        private readonly BlogpostContext? _context;
        public PostService(BlogpostContext context)
        {
            _context = context;
        }
        public void Delete(Blogpost post)
        {
           _context.Blogposts.Remove(post);
        }

        public List<Blogpost> GetAll()
        {
           return _context.Blogposts.ToList();
        }

        public Blogpost GetById(int id)
        {
            return _context.Blogposts.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Blogpost post)
        {
            _context.Blogposts.Add(post);
        }

        public void Update(Blogpost post)
        {
            _context.Blogposts.Update(post);
        }
    }
}
