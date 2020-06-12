using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Dto
{
    public class HospitalDto
    {
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public int AddressId { get; set; }
        public string AddressType { get; set; }

        public string Contact { get; set; }
        public int StreetNo { get; set; }

        public string Area { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int ZipCode { get; set; }


    }
}
