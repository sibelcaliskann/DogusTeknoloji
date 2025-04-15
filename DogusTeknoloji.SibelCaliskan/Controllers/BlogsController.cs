using DogusTeknoloji.SibelCaliskan.Models.Repositories;
using DogusTeknoloji.SibelCaliskan.Models.Services;
using DogusTeknoloji.SibelCaliskan.Models.Services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Xml.Linq;

namespace DogusTeknoloji.SibelCaliskan.Controllers;

[Authorize]
public class BlogsController(IBlogService blogService,ICommentService commentService) : Controller
{
    
    [AllowAnonymous]
    public IActionResult Index(int? categoryId)
    {
        var blogs = blogService.GetBlogsByCategory(categoryId); // filtreli geliyor artık
        var categories = blogService.GetAllCategories(); // kategori listesi

        var model = new CombinedViewModel
        {
            Blogs = blogs,
            Categories = categories
        };

        return View(model);
    }

  
    [HttpGet]
    public IActionResult FilterByCategory(int? categoryId)
    {
        var blogs = categoryId.HasValue
            ? blogService.GetAll().Where(b => b.CategoryId == categoryId.Value).ToList()
            : blogService.GetAll();

        var categories = blogService.GetAllCategories();

        var model = new CombinedViewModel
        {
            Blogs = blogs,
            Categories = categories
        };

        return View("Index", model); 
    }




    [AllowAnonymous]
    public IActionResult Details(int id)
    {
        var blog = blogService.GetById(id);
        if (blog == null)
        {
            return NotFound();
        }

        var comments = commentService.GetCommentsByBlogId(id);

        var viewModel = new BlogViewModel
        {
            Id = blog.Id,
            Title = blog.Title,
            Content = blog.Content,
            AuthorName = blog.AuthorName,
            CategoryName = blog.CategoryName,
            PublishDate = blog.PublishDate,
            ImageUrl = blog.ImageUrl,
            Comments = comments.Select(c => new CommentViewModel
            {
                Id = c.Id,
                BlogId = id,
                UserId = (Guid)c.UserId,
                Content = c.Content,
                CreatedAt = c.CreatedAt,
                UserName = c.User?.UserName ?? "Anonymous"
            }).ToList()
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult AddComment(CreateCommentViewModel createCommentViewModel, int blogId)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Details", new { id = blogId });
        }

        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        commentService.AddComment(createCommentViewModel, blogId, userId);

        return RedirectToAction("Details", new { id = blogId });
    }


    [HttpGet]
    public IActionResult Create()
    {
        var createBlogViewModel = blogService.CreateViewModel();
        return View(createBlogViewModel);
    }

    [HttpPost]
    public IActionResult Create(CreateBlogViewModel createBlogViewModel)
    {
        if (!ModelState.IsValid) return View(blogService.CreateViewModel(createBlogViewModel));

        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        blogService.Create(createBlogViewModel, userId);

        return RedirectToAction("Index");
    }

    //[Authorize(Roles = "Admin")]
    //[HttpGet]
    //public IActionResult Delete(int id)
    //{
    //    blogService.Remove(id);
    //    return RedirectToAction("Index");
    //}


    [HttpGet]
    public IActionResult Delete(int id)
    {
        var blog = blogService.GetById(id);
        if (blog == null)
        {
            return NotFound();
        }

        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        if (blog.UserId != userId)
        {
            return Forbid();
        }

        blogService.Remove(id);
        return RedirectToAction("Index");
    }




    [HttpGet]
    public IActionResult Edit(int id)
    {
        return View(blogService.EditViewModel(id));
    }

    [HttpPost]
    public IActionResult Edit(EditBlogViewModel editBlogViewModel)
    {
        if (!ModelState.IsValid) return View(blogService.EditViewModel(editBlogViewModel));

        blogService.Update(editBlogViewModel);
        return RedirectToAction("Index");
    }
}

