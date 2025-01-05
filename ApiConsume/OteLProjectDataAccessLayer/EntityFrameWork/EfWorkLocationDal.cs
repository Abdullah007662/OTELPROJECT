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
    public class EfWorkLocationDal : GenericRepository<WorkLocation>, IWorkLocationDal
    {
        public EfWorkLocationDal(Context context) : base(context)
        {
        }
    }
}
