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
        private readonly ICoreService<Note> _notedb;
        public TeacherController(ICoreService<Teacher> teacherdb,ICoreService<Lesson> lessondb,ICoreService<Student> studentdb,ICoreService<Note> notedb)
        {
            _teacherdb = teacherdb;
            _lessondb = lessondb;
            _studentdb = studentdb;
            _notedb = notedb;

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
        public IActionResult NoteAdd(int id)
        {
            return View(_studentdb.GetById(id));
        }
        [HttpPost]
        public IActionResult NoteAdd(Student s,int score,int ders)
        {
            //ilk once boyle bir kayit var mi diye bakacagiz onun icin note ait eklemeler yapilacak
            var kayit = _notedb.GetRecord(x => x.StudentId == s.ID && x.LessonId == ders);
            if(kayit==null)
            {
                //note sinifina ait nesne 
                var record = new Note()
                {
                    Score = score,
                    StudentId=s.ID,
                    LessonId=ders
                };
                return _notedb.Add(record) ? View("StudentList", _studentdb.GetAll()) : View();

            }
            return View("StudentList", _studentdb.GetAll());



            
        }

        public IActionResult NoteEdite(int id)
        {
            var result = _notedb.GetRecord(x => x.StudentId==id );
            if(result!=null)
            {
                var studentnote = _studentdb.GetById(result.StudentId);
                var lessonnote = _lessondb.GetById(result.LessonId);

                var record = new StudentNoteDto
                {
                    studentid=result.StudentId,
                    lessonid=result.LessonId,
                    score=result.Score,
                    name=studentnote.Name,
                    surename=studentnote.SureName,
                    Lessons=_lessondb.GetAll()

                };
                return View(record);
            }
            return View();
        }



    }
}
