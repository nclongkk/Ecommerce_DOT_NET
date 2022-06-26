using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce_DOT_NET.Models;

namespace Ecommerce_DOT_NET.Controllers;

public class HeaderController : Controller
{
    private readonly ILogger<HeaderController> _logger;

    public HeaderController(ILogger<HeaderController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}
