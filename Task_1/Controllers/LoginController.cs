using Microsoft.AspNetCore.Mvc;
using Task_1.Models;

namespace Task_1.Controllers;

public class LoginController : Controller
{
    private static List<UserModel> users = new List<UserModel>()
    {
        new UserModel { Id = 1, Username = "admin", Password = "admin", IsAdmin = true },
        new UserModel { Id = 2, Username = "user", Password = "user", IsAdmin = false },
    };
        
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(UserModel model)
    {
        var user = users.SingleOrDefault(u => u.Username == model.Username && u.Password == model.Password);

        if (user != null)
        {
            return RedirectToAction("Index", "Home");
        }
        
        ViewBag.Message = "Invalid username or password";

        return View();
    }

}