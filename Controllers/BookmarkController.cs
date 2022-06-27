using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using daily_blog.Models;
using daily_blog.Services;

namespace daily_blog.Controllers;

public class BookmarkController : Controller
{
    private readonly ILogger<BookmarkController> _logger;
    private BookmarkService bookmarkService;

    public BookmarkController(ILogger<BookmarkController> logger)
    {
        bookmarkService = new BookmarkService();
        _logger = logger;
    }

    [HttpGet("bookmark/{id?}")]
    public IActionResult Index(string id)
    {
        string userId = HttpContext.Session.GetString("user_id");
        if (userId == null)
        {
            return RedirectToAction("Login", "Auth");
        }
        BookmarkModel[] bookmarks = bookmarkService.getAllBookmarkOfUser(int.Parse(userId));
        Console.WriteLine(bookmarks[0].Post.Title);
        ViewData["bookmarks"] = bookmarks;
        ViewData["title"] = "bookmark";
        return View();
    }

    [HttpPost("bookmark/Add")]
    public IActionResult Add(string postId)
    {
        string userId = HttpContext.Session.GetString("user_id");
        if (userId == null)
        {
            return RedirectToAction("Login");
        }
        BookmarkModel bookmark = new BookmarkModel();
        bookmark.UserId = int.Parse(userId);
        bookmark.PostId = int.Parse(postId);
        bookmarkService.add(bookmark);
        return RedirectToAction("Index");
    }

    [HttpPost("bookmark/Delete/{id?}")]
    public IActionResult Delete(string id)
    {
        Console.WriteLine(id);
        string userId = HttpContext.Session.GetString("user_id");
        if (userId == null)
        {
            return RedirectToAction("Login", "Auth");
        }
        bookmarkService.delete(int.Parse(id));
        return RedirectToAction("Index");
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
