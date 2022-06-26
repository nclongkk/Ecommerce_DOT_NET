using Microsoft.AspNetCore.Mvc;
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

    public IActionResult Index()
    {
        return View();
    }
}
