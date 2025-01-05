using OteLProjectDataAccessLayer.Abstract;
using OteLProjectDataAccessLayer.Concrete;
using OteLProjectDataAccessLayer.Repositories;
using OteLProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OteLProjectDataAccessLayer.EntityFrameWork
{
    public class EfAboutDal:GenericRepository<About>,IAboutDal
    {
        public EfAboutDal(Context context) : base(context)
        {
        }
    }
}
