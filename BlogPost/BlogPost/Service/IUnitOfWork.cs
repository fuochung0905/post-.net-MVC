namespace BlogPost.Service
{
    public interface IUnitOfWork
    {
       PostInterface Post { get; }
        TagInterface Tag { get; }
        void Save();
    }
}
