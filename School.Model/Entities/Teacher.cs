using School.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model.Entities
{
    public class Teacher:CoreEntity
    {
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public int LessonID { get; set; }
        public Lesson Lesson { get; set; } //1-1 iliski baglanti propertysi
    }
}
