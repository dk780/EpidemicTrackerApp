using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressType { get; set; }


        public int StreetNo { get; set; }

        public string Area { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int ZipCode { get; set; }
        
        public Patient Patient { get; set; }
        public Hospital Hospitals { get; set; }
        public Organisation  Organisations{get; set; }

    }
}
