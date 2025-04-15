namespace DogusTeknoloji.SibelCaliskan.Models.Services.ViewModels
{
    public class CategoryFilterViewModel
    {
        public int? SelectedCategoryId { get; set; }
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
