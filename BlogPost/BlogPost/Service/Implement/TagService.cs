using BlogPost.DataContext;
using BlogPost.Models;

namespace BlogPost.Service.Implement
{
    public class TagService : TagInterface
    {
        private readonly BlogpostContext? _context;
        public TagService( BlogpostContext context)
        {
            _context = context;
        }

        public void Delete(Tag tag)
        {
            _context.Tags.Remove(tag);
        }

        public List<Tag> GetAll()
        {
           return _context.Tags.ToList();
        }

        public Tag GetById(int id)
        {
            return _context.Tags.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Tag tag)
        {
            _context.Tags.Add(tag);
        }

        public void Update(Tag tag)
        {
          _context.Tags.Update(tag);
        }
    }
}
