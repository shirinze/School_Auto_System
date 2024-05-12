using Microsoft.AspNetCore.Mvc;

namespace School_WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
