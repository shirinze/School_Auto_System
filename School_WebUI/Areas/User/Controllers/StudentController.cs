using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace School_WebUI.Areas.User.Controllers
{
    [Authorize]// Bu kontrollerı login olan görsün istiyoruz
    [Area("User")]
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
