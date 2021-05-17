using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        void Insert(T p);

        T Get(Expression<Func<T, bool>> filter);//listeden sadece bir tane eleman dönderir.idsi 5 olan yazarı getirir
        void Delete(T p);
        void Update(T p);

        List<T> List(Expression<Func<T, bool>> filter);//şartlı listelemedeir.yazar adı ali olanları getir örnek olarak.komple liste dönderir


    }
}
