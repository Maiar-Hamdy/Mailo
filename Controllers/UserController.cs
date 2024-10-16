using Microsoft.AspNetCore.Mvc;

namespace Mailo.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
