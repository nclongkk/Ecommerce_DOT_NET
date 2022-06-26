using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using daily_blog.Models;
using Ecommerce_DOT_NET.Services;
using Ecommerce_DOT_NET.Models;

namespace daily_blog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private UserService userService;

    public HomeController(ILogger<HomeController> logger)
    {
        userService = new UserService();
        _logger = logger;
    }

    public IActionResult Index()
    {
        this.userService.add(new UserModel { Id = 1, Username = "test", Password = "test", Email = "nclongkk@gmail.com", Role = RoleEnum.Admin, CreatedAt = DateTime.Now });

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
