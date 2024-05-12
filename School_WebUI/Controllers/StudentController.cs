using Microsoft.AspNetCore.Mvc;
using School.Core.Service;
using School.Model.Entities;

namespace School_WebUI.Controllers
{
    public class StudentController : Controller
    {
        private readonly ICoreService<Student> _st;
        public StudentController(ICoreService<Student> st)
        {
            _st = st;
        }
        public IActionResult Listele()
        {
            return View(_st.GetAll());
        }
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Student s)
        {
            if(s.Name!=null && s.SureName!=null && s.Gender!=null)
            {
                return _st.Add(s) ? View("Listele", _st.GetAll()) : View();
            }
            ViewBag.StudentAddError = "isim soy isim ve cinsiyet bos gecilemez!!!!!!!!";
            return View();
        }
        public IActionResult Guncelle()
        {
            return View();
        }
        public IActionResult Sil()
        {
            return View();
        }
    }
}
