using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Dto
{
    public class TreatmentRecordsDto
    {
        public int TreatmentRecordsId { get; set; }
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
        public int Org_AddressId { get; set; }
        public string Org_AddressType { get; set; }

        public int Org_StreetNo { get; set; }

        public string Org_Area { get; set; }

        public string Org_City { get; set; }

        public string Org_State { get; set; }

        public string Org_Country { get; set; }

        public int Org_ZipCode { get; set; }
        public int HospitalId { get; set; }

        public string HospitalName { get; set; }

        public string Contact { get; set; }
        public int Hos_AddressId { get; set; }
        public string Hos_AddressType { get; set; }

        public int Hos_StreetNo { get; set; }

        public string Hos_Area { get; set; }

        public string Hos_City { get; set; }

        public string Hos_State { get; set; }

        public string Hos_Country { get; set; }

        public int Hos_ZipCode { get; set; }
        public int DiseaseId { get; set; }

        public string DiseaseName { get; set; }

        public string DiseaseType { get; set; }

        public DateTime AdmittedDate { get; set; }

        public string Prescription { get; set; }

        public DateTime RelievingDate { get; set; }

        public string IsFatal { get; set; }

        public int Currentstage { get; set; }
        
        

    }
}
