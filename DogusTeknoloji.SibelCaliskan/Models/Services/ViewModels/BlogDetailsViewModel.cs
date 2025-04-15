namespace DogusTeknoloji.SibelCaliskan.Models.Services.ViewModels
{
    public class BlogDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public BlogViewModel Blog { get; set; } = null!;
        public List<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();
    }
}
