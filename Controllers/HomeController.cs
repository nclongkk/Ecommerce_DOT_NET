using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using daily_blog.Models;
using daily_blog.Services;

namespace daily_blog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private UserService userService;
    private PostService postService;

    public HomeController(ILogger<HomeController> logger)
    {
        userService = new UserService();
        postService = new PostService();
        _logger = logger;
    }

    [HttpGet("{id?}")]
    public IActionResult Index(string id)
    {
        string userId = HttpContext.Session.GetString("user_id");
        if (userId != null)
        {
            return RedirectToAction("Index", "Post");
        }
        ViewData["title"] = "home page";
        return View();


    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
