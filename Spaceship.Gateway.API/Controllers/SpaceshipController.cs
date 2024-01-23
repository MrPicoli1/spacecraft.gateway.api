using Microsoft.AspNetCore.Mvc;

namespace Spaceship.Gateway.API.Controllers
{
    public class SpaceshipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
