using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Core.Map;
using School.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model.Maps
{
    public class StudentMap:CoreMap<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.SureName).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Gender).HasMaxLength(10).IsRequired(true);
        }
    }
}
