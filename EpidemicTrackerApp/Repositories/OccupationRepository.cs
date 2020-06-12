using EpidemicTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Repositories
{
    public class OccupationRepository : IOccupationRepository
    {
        private readonly EpidemicTrackerAppDBContext Context;

        public OccupationRepository(EpidemicTrackerAppDBContext context)
        {
            Context = context;

        }

        public Occupation Add(Occupation occupation)
        {
            Context.Set<Occupation>().Add(occupation);
            Context.SaveChanges();
            return occupation;
        }

        public Occupation Delete(int OccupationId)
        {
            var occupation = Context.Set<Occupation>().Find(OccupationId);
            if (occupation == null)
            {
                return occupation;
            }

            Context.Set<Occupation>().Remove(occupation);
            Context.SaveChanges();
            return occupation;
        }

        public IEnumerable<Occupation> GetAllOccupation()
        {
            return Context.Set<Occupation>().ToList();
        }

        public Occupation GetOccupation(int OccupationId)
        {
            return Context.Set<Occupation>().Find(OccupationId);
        }

        public Occupation Update(Occupation occupationChanges)
        {
            var occupation = Context.Occupations.Attach(occupationChanges);
            occupation.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return occupationChanges;
        }
    }
}
