using School.Model.Entities;
using System.Collections.Generic;

namespace School_WebUI.Areas.User.Models.Dtos
{
    public class StudentNoteDto
    {
        public int studentid { get; set; }
        public int lessonid { get; set; }
        public int score { get; set; }
        public string name { get; set; }
        public string surename { get; set; }
        public List<Lesson> Lessons { get; set; }

    }
}
