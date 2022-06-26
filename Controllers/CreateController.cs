using Microsoft.AspNetCore.Mvc;
using daily_blog.Models;
using daily_blog.Services;

namespace daily_blog.Controllers;

public class CreateController : Controller
{
    private readonly ILogger<CreateController> _logger;
    private PostService postService;
    public CreateController(ILogger<CreateController> logger)
    {
        postService = new PostService();
        _logger = logger;
    }
    [HttpGet("create/{id?}")]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost("create")]
    public IActionResult Post(PostModel newPost)
    {
        int AuthorId = int.Parse(HttpContext.Session.GetString("user_id"));
        newPost.AuthorId = AuthorId;
        this.postService.add(newPost);
        return RedirectToAction("Index", "Home");
    }
}
