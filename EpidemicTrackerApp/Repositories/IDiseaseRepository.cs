using EpidemicTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Repositories
{
    public interface IDiseaseRepository
    {
        Disease GetDisease(int DiseaseId);
        IEnumerable<Disease> GetAllDisease();

        Disease Add(Disease disease);

        Disease Update(Disease diseaseChanges);
        Disease Delete(int DiseaseId);
    }
}
