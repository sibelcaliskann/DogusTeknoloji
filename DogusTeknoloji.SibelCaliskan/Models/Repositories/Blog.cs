using DogusTeknoloji.SibelCaliskan.Models.Repositories.Entities;

namespace DogusTeknoloji.SibelCaliskan.Models.Repositories
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;

        public DateTime PublishDate { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }
        public Guid UserId { get; set; } 
        public Category Category { get; set; } = null!;
        public AppUser User { get; set; } = null!; 

        public string? ImageUrl { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
