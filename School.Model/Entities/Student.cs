using School.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model.Entities
{
    public class Student:CoreEntity
    {
        public string Name { get; set; }
        public string SureName { get; set; }
        public string Gender { get; set; }
    }
}
