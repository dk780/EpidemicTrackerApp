using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Models
{
    public class TreatmentRecords
    {
        public int TreatmentRecordsId { get; set; }


        public int PatientID { get; set; }

        public Patient Patient { get; set; }

        public int HospitalId { get; set; }

        public Hospital Hospital { get; set; }

        public int DiseaseId { get; set; }

        public Disease Disease { get; set; }

        public DateTime AdmittedDate { get; set; }
        public DateTime RelievingDate { get; set; }
        public string Prescription { get; set; }

        public  int Currentstage { get; set; }
        public string IsFatal { get; set; }

    }


}
