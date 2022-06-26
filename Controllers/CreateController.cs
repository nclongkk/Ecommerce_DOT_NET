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
    [HttpPost]
    public IActionResult Post(PostModel newPost)
    {
        string title = newPost?.Title;
        string image = newPost?.Image;
        string url = newPost?.Url;

        return View();
    }
}
