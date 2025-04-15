using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DogusTeknoloji.SibelCaliskan.Models.Services.ViewModels
{
    public class EditCommentViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Yorum alani boş olamaz")]
        [Display(Name = "Content :")]
        public string? Content { get; set; }

        //[Required(ErrorMessage = "Yayın tarihi boş olamaz")]
        //[Display(Name = "Publish Date :")]
        //[DataType(DataType.Date)]
        //public DateTime? CreatedAt { get; set; }


        
    }
}
