using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Entity
{
    //CoreEntity sinifi tablo olarak olusacak siniflara base class gorevini yerine getirecek
    public class CoreEntity
    {
        public int ID { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
