using EpidemicTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Repositories
{
    public interface IOccupationRepository
    {
        Occupation GetOccupation(int OccupationId);
        IEnumerable<Occupation> GetAllOccupation();

        Occupation Add(Occupation occupation);

        Occupation Update(Occupation occupationChanges);
        Occupation Delete(int OccupationId);
    }
}
