using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Dto
{
    public class OrganisationDto
    {
        public int PatientID { get; set; }
        public int OrganisationId { get; set; }

        public string OrganisationName { get; set; }

        public string OrganisationContact { get; set; }

        public int AddressId { get; set; }
        public string AddressType { get; set; }
        public int StreetNo { get; set; }

        public string Area { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int ZipCode { get; set; }


    }
}
