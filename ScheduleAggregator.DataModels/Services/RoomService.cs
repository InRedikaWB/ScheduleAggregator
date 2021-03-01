﻿using ScheduleAggregator.DataModels.Entities;
using ScheduleAggregator.DataModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAggregator.DataModels.Services
{
    public class RoomService
    {
        private UnitOfWork _uof;
        public RoomService(UnitOfWork uof)
        {
            _uof = uof;
        }
        public void Create(string name)
        {
            if (_uof.Rooms.Get(_ => _.Name == name) != null)
                throw new Exception("The Room already exists");

            _uof.Rooms.Create(new Room() { Name = name });
        }
        public void Update(Room room)
        {
            _uof.Rooms.Update(room);
        }

        ///

        public Room FindByID(int id)
        {
            return _uof.Rooms.FindById(id);
        }

        public IEnumerable<Room> Get()
        {
            return _uof.Rooms.Get();
        }
        public void Remove(Room room)
        {
            _uof.Rooms.Remove(room);
        }
    }
}
