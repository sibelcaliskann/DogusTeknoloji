namespace DogusTeknoloji.SibelCaliskan.Models.Services.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set; } = null!;
    }
}
