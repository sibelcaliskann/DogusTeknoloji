using DogusTeknoloji.SibelCaliskan.Models.Repositories;

namespace DogusTeknoloji.SibelCaliskan.Models.Services.ViewModels
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Category Category { get; set; } = null!; // Kategori nesnesi
        public int CategoryId { get; set; } // Kategori ID'si
        public string CategoryName { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public Guid UserId { get; set; }  // Kullanıcının Id’si
        public string AuthorName { get; set; } = null!; // Kullanıcı adı
        public string? ImageUrl { get; set; }
        //public BlogViewModel Blog { get; set; } = null!;
        public Comment Comment { get; set; } = null!; // Yorum nesnesi
        public List<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();
    }
}
