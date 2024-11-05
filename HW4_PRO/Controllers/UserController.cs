using HW4_PRO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HW4_PRO.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        private readonly Dictionary<string, User> _users = new Dictionary<string, User>()
        {
            ["ivan"] = new User()
            {
                Name = "Ivan",
                Age = 32,
                Email = "ivanpolyan@gmail.com"
            },
            ["tolik"] = new User()
            {
                Name = "Tolik",
                Age = 28,
                Email = "tolikpatko@hotmail.com"
            },
            ["maxim"] = new User()
            {
                Name = "Maxim",
                Age = 50,
                Email = "maximptulk@mail.ua"
            }
        };

        [HttpGet]
        public IActionResult Index(string name, string color)
        {
            ViewBag.Color = IsValidColor(color) ? color : "black";

            if (string.IsNullOrEmpty(name))
            {
                ViewBag.Message = "Error, please write a Name parameter";
                return View("Message");
            }

            if (_users.TryGetValue(name.ToLower(), out User user))
                return View(user);
            else
            {
                ViewBag.Message = $"User with name: {name} not found";
                return View("Message");
            }
        }

        private bool IsValidColor(string color)
        {
            if (string.IsNullOrEmpty(color))
                return false;
            var validColor = new[] { "red", "blue", "black", "green", "green", "orange", "purple" };
            return validColor.Contains(color.ToLower());
        }
    }
}
