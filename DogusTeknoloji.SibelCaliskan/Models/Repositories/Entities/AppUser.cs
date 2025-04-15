using Microsoft.AspNetCore.Identity;

namespace DogusTeknoloji.SibelCaliskan.Models.Repositories.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public DateTime BirthDate { get; set; }
        public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
