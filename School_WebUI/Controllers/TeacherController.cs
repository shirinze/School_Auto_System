using Microsoft.AspNetCore.Mvc;
using School.Core.Service;
using School.Model.Entities;
using System.Runtime.CompilerServices;

namespace School_WebUI.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ICoreService<Teacher> _t;
        public TeacherController(ICoreService<Teacher> t)
        {
            _t = t;
        }
        public IActionResult Listele()
        {
            return View(_t.GetAll());
        }
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Teacher te)
        {
            if(te.TeacherName!=null && te.TeacherSurname!=null)
            {
                return _t.Add(te) ? View("Listele", _t.GetAll()) : View();
            }
            ViewBag.TeacherAddError = "isim ve soyisim bos gecilemez!!!!!!!";
            return View();
        }

        public IActionResult Guncelle(int id)
        {
            return View(_t.GetById(id));
        }
        [HttpPost]
        public IActionResult Guncelle(Teacher te)
        {
            if(te.TeacherName!=null && te.TeacherSurname!=null && te.LessonID!=0)
            {
                return _t.Update(te) ? View("Listele", _t.GetAll()) : View();
            }
            ViewBag.TeacherUpdateError = "isim soyisim ve ders id bos gecilemez";
            return View();
        }
        public IActionResult Sil(int id)
        {
            return _t.Delete(id)?View("Listele",_t.GetAll()):View();
        }
    }
}
