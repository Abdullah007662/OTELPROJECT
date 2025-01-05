using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OteLProjectDataAccessLayer.Abstract;
using OteLProjectDataAccessLayer.Concrete;
using OteLProjectDataAccessLayer.Repositories;
using OteLProjectEntityLayer.Concrete;

namespace OteLProjectDataAccessLayer.EntityFrameWork
{
    public class EfSubscribeDal : GenericRepository<Subscribe>, ISubscribeDal
    {
        public EfSubscribeDal(Context context) : base(context)
        {
        }
    }
}
