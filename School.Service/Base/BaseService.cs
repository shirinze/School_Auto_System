using School.Core.Entity;
using School.Core.Service;
using School.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.Base
{
    // T ifadesinin CoreEntity türünden olmasını istedik
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        private readonly SchoolAutoContext _db;
        public BaseService(SchoolAutoContext db)
        {
            _db = db;
        }
        public bool Add(T item)
        {
            try
            {
                _db.Set<T>().Add(item);
                return Save() > 0;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public bool Delete(int id)
        {
            try
            {
                _db.Set<T>().Remove(GetById(id));
                return Save() > 0;

            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public List<T> GetAll() => _db.Set<T>().ToList();


        public T GetById(int id) => _db.Set<T>().Find(id);

        public T GetRecord(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().FirstOrDefault(expression);
        }

        public int Save() => _db.SaveChanges();

        public bool Update(T item)
        {
            try
            {
                _db.Set<T>().Update(item);
                return Save() > 0;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
