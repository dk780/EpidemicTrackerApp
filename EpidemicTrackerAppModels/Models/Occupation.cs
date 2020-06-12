using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Models
{
    public class Occupation
    {
        public int OccupationId { get; set; }

        public string OccupationName { get; set; }

        public string OccupationType { get; set; }
        public int PatientID { get; set; }
        public Patient Patient { get; set; }


    }
}
