using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using daily_blog.Models;
using daily_blog.Services;

namespace daily_blog.Controllers;

public class PostController : Controller
{
    private readonly ILogger<PostController> _logger;
    private PostService postService;
    private UserService userService;

    public PostController(ILogger<PostController> logger)
    {
        userService = new UserService();
        postService = new PostService();
        _logger = logger;
    }

    [HttpGet("post/{id?}")]
    public IActionResult Index(string id)
    {

        // PostModel[] posts = postService.getAll();
        // ViewData["posts"] = posts;
        if (id == null)
        {
            PostModel[] posts = postService.getAll();
            ViewData["posts"] = posts;
        }
        else
        {
            Console.WriteLine(1);
            PostModel post = postService.getById(int.Parse(id));
            Console.WriteLine(post?.ToString());
            ViewData["post"] = post;
        }
        ViewData["title"] = "post";
        return View();


    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
