using BlogProject.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.CORE.Service
{
    public interface ICoreService<T> where T : CoreEntity
    {
        bool Add(T item);
        bool Add(List<T> items);
        bool Update(T item);
        bool Remove(T item);
        bool Remove(Guid id);
        bool RemoveAll(Expression<Func<T,bool>> exp);//linq sorgusuyla işlemi..
        T GetByID(Guid id);
        T GetByDefault(Expression<Func<T, bool>> exp);
        List<T> GetDefault(Expression<Func<T, bool>> exp);
        List<T> GetActive();
        List<T> GetAll();
        bool Activate(Guid id);//aktifleştir
        bool Any(Expression<Func<T, bool>> exp); //sorgu sonucu var mı?
        int Save();
        
    }
}
