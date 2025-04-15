using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DogusTeknoloji.SibelCaliskan.Models.Services.ViewModels
{
    public class EditBlogViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Blog basligi  boş olamaz")]
        [Display(Name = "Blog Name :")]
        public string? Title { get; set; } = null!;

        [Required(ErrorMessage = "Blog yazi alani  boş olamaz")]
        [Display(Name = "Content :")]
        public string? Content { get; set; }

        [Required(ErrorMessage = "Kategori seçiniz")]
        [Display(Name = "Category :")]
        public int? CategoryId { get; set; }

        [Display(Name = "Image URL :")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Yayın tarihi boş olamaz")]
        [Display(Name = "Publish Date :")]
        [DataType(DataType.Date)]
        public DateTime? PublishDate { get; set; }


        [ValidateNever] public SelectList CategoryList { get; set; } = null!;
    }
}
