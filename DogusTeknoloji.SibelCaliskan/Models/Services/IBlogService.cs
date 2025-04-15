using DogusTeknoloji.SibelCaliskan.Models.Services.ViewModels;

namespace DogusTeknoloji.SibelCaliskan.Models.Services
{
    public interface IBlogService
    {
        CombinedViewModel GetAllData();

        List<BlogViewModel> GetAll();
        List<CategoryViewModel> GetAllCategories();
        List<BlogViewModel> GetBlogsByCategory(int? categoryId);

        CreateBlogViewModel CreateViewModel();

        CreateBlogViewModel CreateViewModel(CreateBlogViewModel createBlogViewModel);

        void Create(CreateBlogViewModel createBlogViewModel, Guid userId);


        BlogViewModel? GetById(int id);
        EditBlogViewModel? EditViewModel(int id);

        EditBlogViewModel? EditViewModel(EditBlogViewModel editBlogViewModel);
        void Remove(int id);
        void Update(EditBlogViewModel editBlogViewModel);
    }
}
