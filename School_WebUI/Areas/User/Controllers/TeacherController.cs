using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using School.Core.Service;
using School.Model.Entities;
using School_WebUI.Areas.User.Models.Dtos;
using System.Linq;

namespace School_WebUI.Areas.User.Controllers
{
    [Authorize] // Bu kontrollerı login olan görsün istiyoruz
    [Area("User")]
    public class TeacherController : Controller
    {
        private readonly ICoreService<Teacher> _teacherdb;
        private readonly ICoreService<Lesson> _lessondb;
        private readonly ICoreService<Student> _studentdb;
        public TeacherController(ICoreService<Teacher> teacherdb,ICoreService<Lesson> lessondb,ICoreService<Student> studentdb)
        {
            _teacherdb = teacherdb;
            _lessondb = lessondb;
            _studentdb = studentdb;
        }
        public IActionResult Index()
        {
            //ogretmene ait id bilgisi
           var id=int.Parse(User.Claims.FirstOrDefault(c=>c.Type.EndsWith("ID")).Value);

            //sorgu yaz
            var result = _teacherdb.GetRecord(x => x.ID == id);
            //Dto olustur
            var record = new TeacherDto
            {
                teachername = result.TeacherName,
                teachersurename = result.TeacherSurname,
                lessonname = _lessondb.GetById(result.LessonID).LessonName
            };
            

            //view Dto nesnesini gonder
            return View(record);
        }

        public IActionResult StudentList()
        {
            return View(_studentdb.GetAll());
        }

    }
}
