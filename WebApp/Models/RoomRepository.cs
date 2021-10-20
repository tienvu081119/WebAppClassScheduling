using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class RoomRepository : BaseRepository
    {
        
        public RoomRepository(CSContext context) : base(context)
        {
            
        }


        public int Edit(Room obj)
        {
            context.Rooms.Update(obj);
            return context.SaveChanges();
        }

        public Room GetById(int id)
        {
            return context.Rooms.Find(id);
        }
        public int Delete(int id)
        {
            context.Rooms.Remove(new Room { Id = id });
            return context.SaveChanges();
        }

        public List<Room> GetRooms()
        {
            return context.Rooms.ToList();
        }

        public int Add(Room obj)
        {
            context.Rooms.Add(obj);
            return context.SaveChanges();
        }         

    }
}
