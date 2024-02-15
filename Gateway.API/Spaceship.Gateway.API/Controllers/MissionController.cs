using Microsoft.AspNetCore.Mvc;

namespace Spaceship.Gateway.API.Controllers
{
    public class MissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
