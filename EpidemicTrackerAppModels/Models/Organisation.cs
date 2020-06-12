using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Models
{
    public class Organisation
    {
        public int OrganisationId { get; set; }

        public string OrganisationName { get; set; }
        public string OrganisationContact { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int PatientID { get; set; }
        public Patient Patient { get; set; }


    }
}
