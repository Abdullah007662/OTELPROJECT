﻿using OteLProjectBusinessLayer.Abstract;
using OteLProjectDataAccessLayer.Abstract;
using OteLProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OteLProjectBusinessLayer.Concrete
{
    public class RoomManager : IRoomService
    {
        // Buraya DepndencyInjecsion Uygulayacagız..
        // Sonra Constractor İçinde Bu degerleri cagıracagız içinde işlem yapmak için ..
        // RoomDal Field(Alan) Oluşturuyoruz 
        private readonly IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public void TDelete(Room t)
        {
            _roomDal.Delete(t);
        }

        public Room TGetByID(int id)
        {
            return _roomDal.GetByID(id);
        }

        public List<Room> TGetList()
        {
            return _roomDal.GetList();
        }

        public void TInsert(Room t)
        {
            _roomDal.Insert(t);
        }

        public int TRoomCount()
        {
            return _roomDal.RoomCount();
        }

        public void TUpdate(Room t)
        {
            _roomDal.Update(t);
        }
    }
}
