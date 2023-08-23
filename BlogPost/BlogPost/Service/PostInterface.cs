using BlogPost.Models;

namespace BlogPost.Service
{
    public interface PostInterface
    {
        public List<Blogpost> GetAll();
        Blogpost GetById(int id);
        void Insert(Blogpost post);
        void Update(Blogpost post);
        void Delete(Blogpost post);

    }
}

