using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DogusTeknoloji.SibelCaliskan.Models.Services.ViewModels
{
    public class CreateCommentViewModel
    {

        public int Id { get; set; }
       


        [Required(ErrorMessage = "Yorumunuzu giriniz")]
        [Display(Name = "Content :")]
        public string? Content { get; set; }

        [Required(ErrorMessage = "Yayın tarihi boş olamaz")]
        [Display(Name = "Publish Date :")]
        [DataType(DataType.Date)]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public string UserName { get; set; } = null!;


    }
}
