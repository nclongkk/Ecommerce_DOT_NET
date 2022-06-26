using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using daily_blog.Models;
using daily_blog.Services;

namespace daily_blog.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;
    private HttpContext httpContext;

    private UserService userService;

    public AuthController(ILogger<AuthController> logger)
    {
        userService = new UserService();
        _logger = logger;
    }


    public IActionResult Index(string id)
    {
        return View();
    }

    [HttpGet("auth/Login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost("auth/Login")]
    public IActionResult Login(string Email, string Password)
    {

        Console.WriteLine(Email);
        UserModel[] userModels = this.userService.getUsersByEmail(Email);
        if (userModels.Length == 0)
        {
            return RedirectToAction("Login");
        }
        else
        {
            if (userModels[0].Password == Password)
            {
                HttpContext.Session.SetString("user_id", userModels[0].Id.ToString());
                string userId = HttpContext.Session.GetString("user_id");
                Console.WriteLine(userId);
                return RedirectToAction("Index", "Post");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
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
