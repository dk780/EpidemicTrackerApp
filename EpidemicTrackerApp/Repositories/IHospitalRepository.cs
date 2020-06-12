using EpidemicTrackerApp.Dto;
using EpidemicTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Repositories
{
    public interface IHospitalRepository
    {
        List<HospitalDto> GetHospital(int? HospitalId);
        List<HospitalDto> GetAllHospital();

        HospitalDto AddHospital(HospitalDto hospitalDto);
        Hospital Put(Hospital hospitalChanges);
        void Delete(int HospitalId);
    }
}
