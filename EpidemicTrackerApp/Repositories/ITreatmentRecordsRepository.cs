using EpidemicTrackerApp.Dto;
using EpidemicTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Repositories
{
    public interface ITreatmentRecordsRepository
    {
        TreatmentRecords GetTreatmentRecords(int TreatmentRecordsId);
        List<TreatmentRecordsDto> GetAllTreatmentRecords();
        List<TreatmentRecordsDto> GetCuredPatients();
        List<TreatmentRecordsDto> GetUnCuredPatients();
        List<TreatmentRecordsDto> GetDeceased();
        TreatmentRecordsDto AddTreatmentRecords(TreatmentRecordsDto treatmentRecordsDto);

        TreatmentRecords Update(TreatmentRecords treatmentRecordsChanges);
        TreatmentRecords Delete(int TreatmentRecordsId);
    }
}
