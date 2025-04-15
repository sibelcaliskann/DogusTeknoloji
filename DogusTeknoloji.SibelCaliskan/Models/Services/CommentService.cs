using DogusTeknoloji.SibelCaliskan.Models.Repositories;
using DogusTeknoloji.SibelCaliskan.Models.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace DogusTeknoloji.SibelCaliskan.Models.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IBlogRepository _blogRepository;

        public CommentService(ICommentRepository commentRepository, IBlogRepository blogRepository)
        {
            _commentRepository = commentRepository;
            _blogRepository = blogRepository;
        }

        public void AddComment(CreateCommentViewModel createCommentViewModel, int blogId, Guid userId)
        {
            //var userId = Guid.Parse(UserId.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty);

            var comment = new Comment
            {
                Content = createCommentViewModel.Content!,
                CreatedAt = DateTime.Now,
                BlogId = blogId,
                UserId = userId
            };

            _commentRepository.AddComment(comment);
           
        
        }


        public List<Comment> GetCommentsByBlogId(int blogId)
        {
            return _commentRepository.GetCommentsByBlogId(blogId);

        }

      

        public CommentViewModel? GetById(int id)
        {
            var comment = _commentRepository.GetById(id);

            if (comment == null)
            {
                return null;
            }

            return new CommentViewModel
            {
                //Content = comment.Content,
                //CreatedAt = comment.CreatedAt,
                //UserName = comment.User?.UserName ?? "Anonymous"
                Id = comment.Id,
                BlogId = comment.BlogId ?? 0,
                UserId = comment.UserId ?? Guid.Empty, // UserId doğru atanıyor
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                UserName = comment.User?.UserName ?? "Anonymous"
            };
        }

        public EditCommentViewModel? EditViewModel(int id)
        {
            var comment = _commentRepository.GetById(id);

            if (comment == null)
            {
                return null;
            }

            return new EditCommentViewModel
            {
                Id = comment.Id,
                Content = comment.Content,
                
            };
        }

        public void Update(EditCommentViewModel editCommentViewModel)
        {
            var comment = _commentRepository.GetById(editCommentViewModel.Id);

            if (comment == null)
            {
                throw new ArgumentException("Comment not found.");
            }

            comment.Content = editCommentViewModel.Content!;
            comment.CreatedAt = DateTime.Now; // Düzenleme sırasında mevcut zamana ayarlanıyor

            _commentRepository.Update(comment);
        }


        public void Remove(int id)
        {
            var comment = _commentRepository.GetById(id);

            if (comment == null)
            {
                throw new ArgumentException("Comment not found.");
            }

            _commentRepository.Remove(comment);
        }
    }

}
