using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Models
{
    public class Hospital
    {
        public int HospitalId { get; set; }

        public string HospitalName { get; set; }

        public string Contact { get; set; }
        public int AddressId { get; set; }

        public Address Address { get; set; }



        public List<TreatmentRecords> TreatmentRecords { get; set; }





    }
}
