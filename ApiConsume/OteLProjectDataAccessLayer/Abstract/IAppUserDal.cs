﻿using OteLProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OteLProjectDataAccessLayer.Abstract
{
    public interface IAppUserDal:IGenericDal<AppUser>
    {
        List<AppUser> UserListWithWorkLocation();
        List<AppUser> UserListWithWorkLocations();
        int AppUserCount();
    }
}
