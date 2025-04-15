using Microsoft.EntityFrameworkCore;
using DogusTeknoloji.SibelCaliskan.Models.Services.ViewModels;

namespace DogusTeknoloji.SibelCaliskan.Models.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _context;

        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public List<BlogViewModel> GetBlogsByCategory(int? categoryId)
{
    var query = _context.Blogs
        .Include(b => b.Category)
        .Include(b => b.User)
        .AsQueryable();

    if (categoryId.HasValue)
    {
        query = query.Where(b => b.CategoryId == categoryId.Value);
    }

    return query.Select(blog => new BlogViewModel
    {
        Id = blog.Id,
        Title = blog.Title,
        Content = blog.Content,
        PublishDate = blog.PublishDate,
        CategoryId = blog.CategoryId,
        CategoryName = blog.Category != null ? blog.Category.Name : "Kategori Yok",
        Category = blog.Category,
        UserId = blog.UserId,
        AuthorName = blog.User.UserName!,
        ImageUrl = blog.ImageUrl
    }).ToList();
}


        public List<Blog> GetAll()
        {
            //eager loading
            return _context.Blogs.Include(x => x.Category).Include(x => x.User).ToList();
           // return _context.Blogs.Include(x => x.Category).ToList();
        }

        public Blog? GetById(int id)
        {
            return _context.Blogs
        .Include(b => b.User)
        .Include(b => b.Category)
        .FirstOrDefault(b => b.Id == id);
        }

        public void Add(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }

        public void Update(Blog blog)
        {
            _context.Blogs.Update(blog);
            _context.SaveChanges();
        }


        public void Delete(Blog blog)
        {
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
        }
    }
}
