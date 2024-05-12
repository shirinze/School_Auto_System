using Microsoft.EntityFrameworkCore;
using School.Model.Entities;
using School.Model.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model.Context
{
    public class SchoolAutoContext : DbContext
    {
        public SchoolAutoContext(DbContextOptions<SchoolAutoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LessonMap()); // LessonMap sınıfı içindeki değişiklikler tablo oluşturulurken dikkate alınıyor


            base.OnModelCreating(modelBuilder);//coremap sinifi icin calisacak
        }

        public DbSet<Lesson> Lessons { get; set; }


    }
}