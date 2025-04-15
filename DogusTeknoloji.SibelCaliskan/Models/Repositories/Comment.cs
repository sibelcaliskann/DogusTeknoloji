using DogusTeknoloji.SibelCaliskan.Models.Repositories.Entities;

namespace DogusTeknoloji.SibelCaliskan.Models.Repositories
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

       
        public int? BlogId { get; set; }
        public Blog? Blog { get; set; } 

       
        public Guid? UserId { get; set; }
        public AppUser? User { get; set; } 
    }
}
