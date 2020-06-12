using EpidemicTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Dto
{
    public class PatientDto
    {
        public int PatientID { get; set; }

        
        public string PatientName { get; set; }

        public int PAge { get; set; }

        public string PGender { get; set; }

        
        public string PEmail { get; set; }

        public string AadharID { get; set; }

        public long PContact { get; set; }
        public int AddressId { get; set; }
        public string AddressType { get; set; }
        public int StreetNo { get; set; }

        public string Area { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int ZipCode { get; set; }




        public int OccupationId { get; set; }
        public string OccupationName { get; set; }

        public string OccupationType { get; set; }


        public int OrganisationId { get; set; }
        public string OrganisationName { get; set; }

        public string OrganisationContact { get; set; }

    }
}
