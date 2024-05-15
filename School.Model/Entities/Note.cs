using School.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model.Entities
{
    public class Note:CoreEntity
    {
        public int Score { get; set; }
        public int StudentId { get; set; } //foreign key
        public Student Student { get; set; }
        public int LessonId { get; set; } //foreign key
        public Lesson Lesson { get; set; }


    }
}
