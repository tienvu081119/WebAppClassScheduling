using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class TimeslotRepository : BaseRepository
    {       
        public TimeslotRepository(CSContext context) : base(context)
        {
         
        }

        public int Edit(Timeslot obj)
        {
            context.Timeslots.Update(obj);
            return context.SaveChanges();
        }

        public Timeslot GetTimeslotById(int id)
        {
            return context.Timeslots.Find(id);
        }

        public int Delete(int id)
        {
            context.Timeslots.Remove(new Timeslot { Id = id });
            return context.SaveChanges();
        }

        public List<Timeslot> GetTimeslots()
        {
            return context.Timeslots.ToList();
        }

        public int Add(Timeslot obj)
        {
            context.Timeslots.Add(obj);
            return context.SaveChanges();
        }

    }
}
