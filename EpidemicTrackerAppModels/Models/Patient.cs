using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Models
{
    public class Patient
    {
        //public int PatientID { get; set; }
        public int PatientID { get; set; }

        
        public string PatientName { get; set; }

        public int PAge { get; set; }

        public string PGender { get; set; }

        
        public string PEmail { get; set; }

        public string AadharID { get; set; }

        public long PContact { get; set; }
      
      public Occupation Occupation { get; set; }
        public int AddressId { get; set; }


        public Address Address { get; set; }


        public Organisation Organisation { get; set; }
        public List<TreatmentRecords> TreatmentRecords { get; set; }


    }
}
