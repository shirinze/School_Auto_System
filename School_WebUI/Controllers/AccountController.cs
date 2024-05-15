using Microsoft.AspNetCore.Mvc;

namespace School_WebUI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
