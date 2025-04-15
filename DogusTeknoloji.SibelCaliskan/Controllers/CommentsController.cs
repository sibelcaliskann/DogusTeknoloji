using DogusTeknoloji.SibelCaliskan.Models.Services.ViewModels;
using DogusTeknoloji.SibelCaliskan.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DogusTeknoloji.SibelCaliskan.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace DogusTeknoloji.SibelCaliskan.Controllers
{
    [Authorize] 
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

       
        public IActionResult Index()
        {
            
            return View();
        }

        // Yorum oluşturma formu
        [HttpGet]
        public IActionResult Create(int blogId)
        {
            ViewData["BlogId"] = blogId;
            ViewData["UserId"] = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            ViewData["CreatedAt"] = DateTime.Now; 

            return View(new CreateCommentViewModel());
        }

        
        [HttpPost]
        public IActionResult Create(CreateCommentViewModel createCommentViewModel, int blogId)
        {
            if (!ModelState.IsValid)
            {
                
                ViewData["BlogId"] = blogId;
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); 
                ViewData["CreatedAt"] = DateTime.Now; 

                _commentService.AddComment(createCommentViewModel, blogId, userId);
            }

            return RedirectToAction("Details", "Blogs", new { id = blogId });
        }


        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, int blogId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var comment = _commentService.GetById(id);

            if (comment == null)
            {
                return NotFound();
            }
            Console.WriteLine($"Giriş yapan kullanıcı ID: {userId}");
            Console.WriteLine($"Yorumun sahibi kullanıcı ID: {comment.UserId}");
            if (comment.UserId != userId)
            {
                return Unauthorized("Bu yorumu silme yetkiniz yok.");
            }

            _commentService.Remove(id);
            return RedirectToAction("Details", "Blogs", new { id = blogId });
        }



       
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var editViewModel = _commentService.EditViewModel(id);
            if (editViewModel == null)
            {
                return NotFound("Comment not found.");
            }

            return View(editViewModel);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditCommentViewModel editCommentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editCommentViewModel);
            }

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var comment = _commentService.GetById(editCommentViewModel.Id);

            if (comment == null || comment.UserId != userId)
            {
                return Unauthorized("Bu yorumu düzenleme yetkiniz yok.");
            }

            _commentService.Update(editCommentViewModel);
            return RedirectToAction("Details", "Blogs", new { id = comment.BlogId });
        }

        

        
        [HttpGet]
        public IActionResult GetCommentsByBlogId(int blogId)
        {
            var comments = _commentService.GetCommentsByBlogId(blogId);
            return PartialView("_CommentsList", comments); 
        }
    }

}
