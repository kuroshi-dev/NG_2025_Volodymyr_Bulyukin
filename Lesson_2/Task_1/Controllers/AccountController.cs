using Microsoft.AspNetCore.Mvc;
using Task_1.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Task_1.Controllers;

public class AccountController : Controller
{
    private static List<UserModel> users = new List<UserModel>()
    {
        new UserModel { Id = 1, Username = "admin", Password = "admin", IsAdmin = true },
        new UserModel { Id = 2, Username = "user", Password = "user", IsAdmin = false },
    };

    [HttpGet("login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost("login")]
    public ActionResult Login(UserModel model)
    {
        var user = users.SingleOrDefault(u => u.Username == model.Username && u.Password == model.Password);
        
        if (user != null)
        {
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("IsAdmin", user.IsAdmin.ToString());
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Message = "Invalid username or password";
        return View();
    }

    [HttpPost("logout")]
    public ActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}