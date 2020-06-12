using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Models
{
    public class Disease
    {
        public int DiseaseId { get; set; }

        public string DiseaseName { get; set; }

        public string DiseaseType { get; set; }

        public List<TreatmentRecords> TreatmentRecords { get; set; }
    }
}
