using BlogPost.Models;

namespace BlogPost.Service
{
    public interface TagInterface
    {
        public List<Tag> GetAll();
        Tag GetById(int id);
        void Insert(Tag tag);
        void Update(Tag tag);
        void Delete(Tag tag);
    }
}
