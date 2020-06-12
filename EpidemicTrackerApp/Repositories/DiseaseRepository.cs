using EpidemicTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Repositories
{
    public class DiseaseRepository : IDiseaseRepository
    {
        private readonly EpidemicTrackerAppDBContext Context;

        public DiseaseRepository(EpidemicTrackerAppDBContext context)
        {
            Context = context;

        }

        public Disease Add(Disease disease)
        {
            Context.Set<Disease>().Add(disease);
            Context.SaveChanges();
            return disease;
        }

        public Disease Delete(int DiseaseId)
        {
            var disease = Context.Set<Disease>().Find(DiseaseId);
            if (disease == null)
            {
                return disease;
            }

            Context.Set<Disease>().Remove(disease);
            Context.SaveChanges();
            return disease;
        }

        public IEnumerable<Disease> GetAllDisease()
        {
            return Context.Set<Disease>().ToList();
        }

        public Disease GetDisease(int DiseaseId)
        {
            return Context.Set<Disease>().Find(DiseaseId);
        }

        public Disease Update(Disease diseaseChanges)
        {
            var disease = Context.Diseases.Attach(diseaseChanges);
            disease.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return diseaseChanges;
        }
    }
}
