using DogusTeknoloji.SibelCaliskan.Models.Repositories;
using DogusTeknoloji.SibelCaliskan.Models.Services.ViewModels;


namespace DogusTeknoloji.SibelCaliskan.Models.Services
{
    public interface ICommentService
    {
        // Yorum ekleme
        void AddComment(CreateCommentViewModel createCommentViewModel, int blogId, Guid userId);

        // Blog ID'ye göre yorumları getir
        List<Comment> GetCommentsByBlogId(int blogId);

        // Yorum ID'ye göre detayları getir
        CommentViewModel? GetById(int id);

        // Yorum düzenleme için gerekli verileri getir
        EditCommentViewModel? EditViewModel(int id);

        // Yorum güncelleme
        void Update(EditCommentViewModel editCommentViewModel);

        // Yorum silme
        void Remove(int id);
    }
}
