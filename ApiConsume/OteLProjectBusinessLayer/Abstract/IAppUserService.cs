using OteLProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OteLProjectBusinessLayer.Abstract
{
    public interface IAppUserService:IGenericService<AppUser>
    {
        List<AppUser> TUserListWithWorkLocation();
        List<AppUser> TUserListWithWorkLocations();
        int TAppUserCount();
    }
}
