using OteLProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OteLProjectDataAccessLayer.Abstract
{
    public interface IStaffDal:IGenericDal<Staff>
    {
        int GetStaffCount();
        List<Staff> List4Staffs();
    }
}
