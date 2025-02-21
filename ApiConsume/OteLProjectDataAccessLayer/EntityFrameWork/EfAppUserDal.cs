﻿using Microsoft.EntityFrameworkCore;
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
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public EfAppUserDal(Context context) : base(context)
        {
        }

        public int AppUserCount()
        {
            var context = new Context();
            var value = context.Users.Count();
            return value;
        }

        public List<AppUser> UserListWithWorkLocation()
        {
            //Include Dahil Et demek
            var context = new Context();
            return context.Users.Include(x => x.WorkLocation).ToList();
        }

        public List<AppUser> UserListWithWorkLocations()
        {
            var context = new Context();
            return context.Users.Include(x => x.WorkLocation).ToList();
        }
    }
}
