using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Dto
{
    public class DiseaseDto
    {
        public int DiseaseId { get; set; }

        public string DiseaseName { get; set; }

        public string DiseaseType { get; set; }
    }
}
