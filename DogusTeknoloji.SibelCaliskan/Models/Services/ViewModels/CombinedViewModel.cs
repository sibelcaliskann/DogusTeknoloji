namespace DogusTeknoloji.SibelCaliskan.Models.Services.ViewModels
{
    public class CombinedViewModel
    {
        public List<BlogViewModel> Blogs { get; set; } = new List<BlogViewModel>();
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }

}
