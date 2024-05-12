using School.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Service
{
    // ICoreService interface kullanılacak sql sorgu yazımlarının tanımlarının yapıldığı arayüzdür.
    // T ifadesi burada CoreEntity'den miras almış bir sınıfı temsil etmektedir.
    public interface ICoreService<T> where T:CoreEntity
    {
        //crud
        bool Add(T item);
        bool Delete(int id);
        bool Update(T item);
        T GetById(int id);
        List<T> GetAll();
        int Save(); 
        

    }
}
