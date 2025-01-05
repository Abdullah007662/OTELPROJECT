using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OteLProjectDataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T:class // Dışarıdan bir T değeri Alsın Ama Bu T Degeri Bir Class Olmak Zorunda
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetList();
        T GetByID(int id);

    }
}
