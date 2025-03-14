using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Task_1.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Task_1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var username = HttpContext.Session.GetString("Username");
        var isAdmin = bool.Parse(HttpContext.Session.GetString("IsAdmin") ?? "false");

        if (string.IsNullOrEmpty(username))
        {
            return RedirectToAction("Login", "Account");
        }
        ViewBag.Username = username;
        ViewBag.Message = $"You are {(isAdmin ? "an admin" : "a user")}";
        return View();
    }

    [HttpGet("privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet("error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}