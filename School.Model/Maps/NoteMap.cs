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
    public class NoteMap:CoreMap<Note>
    {
        public override void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.Property(x => x.Score).IsRequired(true);
        }
    }
}
