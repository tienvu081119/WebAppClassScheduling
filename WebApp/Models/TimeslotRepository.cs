using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class TimeslotRepository
    {
        CSContext context;
        public TimeslotRepository(CSContext context)
        {
            this.context = context;
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
