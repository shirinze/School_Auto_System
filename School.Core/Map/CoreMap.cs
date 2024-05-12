using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Map
{
    //T herhangi bir dosya olabilir
    //where T:CoreEntity => T ifadesi coreentity ve ya coreentity den miras almis olmasini istedik
    //CoreMap sinifi ile olusacak tablonun design kismiyla ila ilgili kontrolleri yazariz
    //Fluent Api kullandik
    public abstract class CoreMap<T> : IEntityTypeConfiguration<T> where T : CoreEntity  //constrate(kisitliyici)
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.CreateDate).IsRequired(false);
            builder.Property(x => x.UpdateDate).IsRequired(false);
            
        }
    }
}
