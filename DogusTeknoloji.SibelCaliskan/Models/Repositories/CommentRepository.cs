using Microsoft.EntityFrameworkCore;

namespace DogusTeknoloji.SibelCaliskan.Models.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

       
      
        public void AddComment(Comment comment)
        {
            try
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }

        }

       
        public List<Comment> GetCommentsByBlogId(int blogId)
        {
            return _context.Comments
                .Include(c => c.User) // Kullanıcı bilgilerini dahil et
                .Where(c => c.BlogId == blogId)
                .ToList();
        }

        
        public Comment? GetById(int id)
        {
            return _context.Comments
                .Include(c => c.User) // Kullanıcı bilgilerini dahil et
                .FirstOrDefault(c => c.Id == id);
        }

        
        public void Update(Comment comment)
        {
            _context.Comments.Update(comment);
            _context.SaveChanges();
        }

        
        public void Remove(Comment comment)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

    }
}
