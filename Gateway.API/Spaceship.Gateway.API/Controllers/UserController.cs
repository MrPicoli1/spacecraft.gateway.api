using Microsoft.AspNetCore.Mvc;

namespace Spaceship.Gateway.API.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
