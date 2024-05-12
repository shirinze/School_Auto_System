using Microsoft.AspNetCore.Mvc;
using School.Core.Service;
using School.Model.Entities;

namespace School_WebUI.Controllers
{
    public class LessonController : Controller
    {
        private readonly ICoreService<Lesson> _les;
        public LessonController(ICoreService<Lesson> les)
        {
            _les = les;
        }
        public IActionResult Listele()
        {
            return View(_les.GetAll());
        }
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Lesson l)
        {
            if(l.LessonName!=null)
            {
                return _les.Add(l) ? View("Listele", _les.GetAll()) : View();
            }

            ViewBag.LessonAddError = "Ders adini bos gecemezsiniz!!!!";
            return View();
        }
        public IActionResult Guncelle(int id)
        {
            return View(_les.GetById(id));
        }
        [HttpPost]
        public IActionResult Guncelle(Lesson l)
        {
            if(l.LessonName!=null)
            {
                return _les.Update(l) ? View("Listele", _les.GetAll()) : View();
            }
            ViewBag.LessonUpdateError = "Ders adini bos gecemezsiniz!!!!!!!";
            return View();
        }
        public IActionResult Sil(int id)
        {
            return _les.Delete(id)?View("Listele",_les.GetAll()):View();
        }


    }
}
