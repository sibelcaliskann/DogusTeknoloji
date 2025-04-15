using DogusTeknoloji.SibelCaliskan.Models.Repositories;
using DogusTeknoloji.SibelCaliskan.Models.Services.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DogusTeknoloji.SibelCaliskan.Models.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BlogService(IBlogRepository blogRepository, ICategoryRepository categoryRepository)
        {
            _blogRepository = blogRepository;
            _categoryRepository = categoryRepository;
        }
        //public List<CategoryViewModel> GetAllCategories()
        //{
        //    return _categoryRepository.GetAll()
        //        .Select(c => new CategoryViewModel
        //        {
        //            Id = c.Id,
        //            Name = c.Name
        //        })
        //        .ToList();
        //}

        public List<CategoryViewModel> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            if (categories == null || !categories.Any())
            {
                throw new Exception("No categories found in the database.");
            }

            return categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }

        

        public List<BlogViewModel> GetBlogsByCategory(int? categoryId)
        {
            var blogs = _blogRepository.GetBlogsByCategory(categoryId);

            return blogs.Select(blog => new BlogViewModel
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                PublishDate = blog.PublishDate,
                CategoryId = blog.CategoryId,
                CategoryName = blog.Category?.Name ?? "Kategori Yok",
                Category = blog.Category,
                UserId = blog.UserId,
                //AuthorName = blog.User.UserName!,
                ImageUrl = blog.ImageUrl
            }).ToList();
        }




        public List<BlogViewModel> GetAll()
        {
            var blogsList = _blogRepository.GetAll();
            var blogViewModelList = new List<BlogViewModel>();

            foreach (var blog in blogsList)
            {
                var blogViewModel = new BlogViewModel
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Content = blog.Content,
                    PublishDate = blog.PublishDate, // Fixing the type conversion issue  
                    CategoryName = blog.Category.Name,
                    UserId = blog.UserId,
                    AuthorName = blog.User.UserName!,
                    ImageUrl = blog.ImageUrl
                };
                blogViewModelList.Add(blogViewModel);
            }

            return blogViewModelList;
        }
        //public List<BlogViewModel> GetAll()
        //{
        //    var blogsList = _blogRepository.GetAll();
        //    var blogViewModelList = blogsList.Select(blog => new BlogViewModel
        //    {
        //        Id = blog.Id,
        //        Title = blog.Title,
        //        Content = blog.Content,
        //        PublishDate = blog.PublishDate,
        //        CategoryId = blog.CategoryId,
        //        CategoryName = blog.Category.Name,
        //        Category = blog.Category,
        //        UserId = blog.UserId,
        //        AuthorName = blog.User.UserName!,
        //        ImageUrl = blog.ImageUrl
        //    }).ToList();

        //    return blogViewModelList;
        //}



        public CreateBlogViewModel CreateViewModel()
        {
            var categories = _categoryRepository.GetAll();
            var model = new CreateBlogViewModel
            {
                CategoryList = new SelectList(categories, "Id", "Name")
            };
            return model;
        }

        public CreateBlogViewModel CreateViewModel(CreateBlogViewModel createBlogViewModel)
        {
            var categories = _categoryRepository.GetAll();
            createBlogViewModel.CategoryList = new SelectList(categories, "Id", "Name", createBlogViewModel.CategoryId);
            return createBlogViewModel;
        }

        public void Create(CreateBlogViewModel createBlogViewModel, Guid userId)
        {
            var blog = new Blog
            {
                Title = createBlogViewModel.Title!,
                Content = createBlogViewModel.Content!,
                PublishDate = DateTime.Now,
                CategoryId = createBlogViewModel.CategoryId!.Value,
                UserId = userId,
                ImageUrl = createBlogViewModel.ImageUrl

            };

            _blogRepository.Add(blog);
        }

        public BlogViewModel? GetById(int id)
        {
            var blog = _blogRepository.GetById(id);
            if (blog == null) return null!;

            var blogsViewModel = new BlogViewModel
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                PublishDate = blog.PublishDate,
                CategoryName = blog.Category.Name,
                UserId = blog.UserId,
                AuthorName = blog.User.UserName!,
                ImageUrl = blog.ImageUrl
            };
            return blogsViewModel;
        }


        public void Remove(int id)
        {
            var blog = _blogRepository.GetById(id);
            if (blog != null) _blogRepository.Delete(blog);
        }

        public EditBlogViewModel? EditViewModel(int id)
        {
            var blog = _blogRepository.GetById(id);
            if (blog == null) return null;

            var categories = _categoryRepository.GetAll();
            var editBlogViewModel = new EditBlogViewModel
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                CategoryId = blog.CategoryId,
                CategoryList = new SelectList(categories, "Id", "Name", blog.CategoryId)
            };

            return editBlogViewModel;
        }

        public void Update(EditBlogViewModel editBlogViewModel)
        {
            var blog = _blogRepository.GetById(editBlogViewModel.Id);
            if (blog == null) return;

            blog.Title = editBlogViewModel.Title!;
            blog.Content = editBlogViewModel.Content!;
            blog.CategoryId = editBlogViewModel.CategoryId!.Value;
            blog.ImageUrl = editBlogViewModel.ImageUrl;

            _blogRepository.Update(blog);
        }

        public EditBlogViewModel? EditViewModel(EditBlogViewModel editBlogViewModel)
        {
            var categories = _categoryRepository.GetAll();
            editBlogViewModel.CategoryList = new SelectList(categories, "Id", "Name", editBlogViewModel.CategoryId);
            return editBlogViewModel;
        }

        public CombinedViewModel GetAllData()
        {
            // Blogları al
            var blogsList = _blogRepository.GetAll();
            var blogViewModelList = blogsList.Select(blog => new BlogViewModel
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                PublishDate = blog.PublishDate,
                CategoryName = blog.Category.Name,
                UserId = blog.UserId,
                AuthorName = blog.User.UserName!,
                ImageUrl = blog.ImageUrl
            }).ToList();

            // Kategorileri al
            var categories = _categoryRepository.GetAll()
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            // Bloglar ve kategorileri birleştir
            return new CombinedViewModel
            {
                Blogs = blogViewModelList,
                Categories = categories
            };
        }


    }
}
    
