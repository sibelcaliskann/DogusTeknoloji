namespace DogusTeknoloji.SibelCaliskan.Models.Services.ViewModels
{

    public class IndexViewModel
    {
        public List<BlogViewModel> Blogs { get; set; } = new List<BlogViewModel>();
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }



}
