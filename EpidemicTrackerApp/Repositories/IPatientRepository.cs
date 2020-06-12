using EpidemicTrackerApp.Dto;
using EpidemicTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Repositories
{
    public interface IPatientRepository
    {
        List<PatientDto> GetPatient(int? PatientId);
        List<PatientDto> GetAllPatient();

        PatientDto AddPatient(PatientDto patientDto);

        Patient Update(Patient patientChanges);
        Patient Delete(int PatientId);
    }
}
