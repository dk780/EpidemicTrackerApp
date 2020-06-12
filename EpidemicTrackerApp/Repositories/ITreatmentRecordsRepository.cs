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

        TreatmentRecordsDto AddTreatmentRecords(TreatmentRecordsDto treatmentRecordsDto);

        TreatmentRecords Update(TreatmentRecords treatmentRecordsChanges);
        TreatmentRecords Delete(int TreatmentRecordsId);
    }
}
