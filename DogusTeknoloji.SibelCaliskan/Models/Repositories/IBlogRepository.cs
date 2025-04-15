namespace DogusTeknoloji.SibelCaliskan.Models.Repositories;
using DogusTeknoloji.SibelCaliskan.Models.Services.ViewModels;

    public interface IBlogRepository
    {
        List<Blog> GetAll();
        List<Category> GetAllCategories();
        List<BlogViewModel> GetBlogsByCategory(int? categoryId); 
        Blog? GetById(int id);
        void Add(Blog blog);
        void Update(Blog blog);
        void Delete(Blog blog);
    }

