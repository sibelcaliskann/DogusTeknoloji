namespace DogusTeknoloji.SibelCaliskan.Models.Repositories
{
    public interface ICommentRepository
    {
        void AddComment(Comment comment);
        List<Comment> GetCommentsByBlogId(int blogId);
        Comment? GetById(int id);
        void Update(Comment comment);
        void Remove(Comment comment);
        
    }
}
