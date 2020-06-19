using EpidemicTrackerApp.Dto;
using EpidemicTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Repositories
{
    public class TreatmentRecordsRepository : ITreatmentRecordsRepository
    {
        private readonly EpidemicTrackerAppDBContext Context;

        public TreatmentRecordsRepository(EpidemicTrackerAppDBContext context)
        {
            Context = context;

        }

        public TreatmentRecordsDto AddTreatmentRecords(TreatmentRecordsDto treatmentRecordsDto)
        {
            Address addr = new Address()
            {
                AddressId = treatmentRecordsDto.AddressId,
                AddressType = treatmentRecordsDto.AddressType,
                StreetNo = treatmentRecordsDto.StreetNo,
                Area = treatmentRecordsDto.Area,
                City = treatmentRecordsDto.City,
                State = treatmentRecordsDto.State,
                Country = treatmentRecordsDto.Country,
                ZipCode = treatmentRecordsDto.ZipCode,
            };
            Context.Addresses.Add(addr);
            Context.SaveChanges();
            int addressid = addr.AddressId;

            Patient pat = new Patient()
            {
                PatientID = treatmentRecordsDto.PatientID,
                PatientName = treatmentRecordsDto.PatientName,
                PAge = treatmentRecordsDto.PAge,
                PGender = treatmentRecordsDto.PGender,
                PEmail = treatmentRecordsDto.PEmail,
                AadharID = treatmentRecordsDto.AadharID,
                PContact = treatmentRecordsDto.PContact,
                AddressId = addressid,
            };
            Context.Patients.Add(pat);
            Context.SaveChanges();
            int patientid = pat.PatientID;

            Occupation occ = new Occupation()
            {
                OccupationId = treatmentRecordsDto.OccupationId,
                OccupationName = treatmentRecordsDto.OccupationName,
                OccupationType = treatmentRecordsDto.OccupationType,
                PatientID = patientid,
            };
            Context.Occupations.Add(occ);
            Context.SaveChanges();
            int occupationid = occ.OccupationId;

            Address orgaddr = new Address()
            {
                AddressId = treatmentRecordsDto.Org_AddressId,
                AddressType = treatmentRecordsDto.Org_AddressType,
                StreetNo = treatmentRecordsDto.Org_StreetNo,
                Area = treatmentRecordsDto.Org_Area,
                City = treatmentRecordsDto.Org_City,
                State = treatmentRecordsDto.Org_State,
                Country = treatmentRecordsDto.Org_Country,
                ZipCode = treatmentRecordsDto.Org_ZipCode,
            };
            Context.Addresses.Add(orgaddr);
            Context.SaveChanges();
            int orgaddressid = orgaddr.AddressId;

            Organisation org = new Organisation()
            {
                OrganisationId = treatmentRecordsDto.OrganisationId,
                OrganisationName = treatmentRecordsDto.OrganisationName,
                OrganisationContact = treatmentRecordsDto.OrganisationContact,
                PatientID = patientid,
                AddressId = orgaddressid,
            };
            Context.Organisations.Add(org);
            Context.SaveChanges();

            Address hosaddr = new Address()
            {
                AddressId = treatmentRecordsDto.Hos_AddressId,
                AddressType = treatmentRecordsDto.Hos_AddressType,
                StreetNo = treatmentRecordsDto.Hos_StreetNo,
                Area = treatmentRecordsDto.Hos_Area,
                City = treatmentRecordsDto.Hos_City,
                State = treatmentRecordsDto.Hos_State,
                Country = treatmentRecordsDto.Hos_Country,
                ZipCode = treatmentRecordsDto.Hos_ZipCode,
            };
            Context.Addresses.Add(hosaddr);
            Context.SaveChanges();
            int hosaddressid = hosaddr.AddressId;

            Hospital hos = new Hospital()
            {
                HospitalId = treatmentRecordsDto.HospitalId,
                HospitalName = treatmentRecordsDto.HospitalName,
                Contact = treatmentRecordsDto.Contact,
                AddressId = hosaddressid,

            };
            Context.Hospitals.Add(hos);
            Context.SaveChanges();
            int hospitalid = hos.HospitalId;

            Disease dis = new Disease()
            {
                DiseaseId = treatmentRecordsDto.DiseaseId,
                DiseaseName = treatmentRecordsDto.DiseaseName,
                DiseaseType = treatmentRecordsDto.DiseaseType
            };
            Context.Diseases.Add(dis);
            Context.SaveChanges();
            int diseaseid = dis.DiseaseId;

            

            TreatmentRecords trtr = new TreatmentRecords()
            {
                TreatmentRecordsId = treatmentRecordsDto.TreatmentRecordsId,
                PatientID = patientid,
                HospitalId = hospitalid,
                DiseaseId = diseaseid,
                AdmittedDate = treatmentRecordsDto.AdmittedDate,
                Prescription = treatmentRecordsDto.Prescription,
                RelievingDate = treatmentRecordsDto.RelievingDate,
                IsFatal = treatmentRecordsDto.IsFatal,
                Currentstage = treatmentRecordsDto.Currentstage
            };
            Context.TreatmentRecords.Add(trtr);
            Context.SaveChanges();
            int treatmentrecordsid = trtr.TreatmentRecordsId;

            return treatmentRecordsDto;
        }

        public TreatmentRecords Delete(int TreatmentRecordsId)
        {
            var treatmentRecords = Context.Set<TreatmentRecords>().Find(TreatmentRecordsId);
            if (treatmentRecords == null)
            {
                return treatmentRecords;
            }

            Context.Set<TreatmentRecords>().Remove(treatmentRecords);
            Context.SaveChanges();
            return treatmentRecords;
        }

        public List<TreatmentRecordsDto> GetAllTreatmentRecords()
        {

            var treatmentrecords = (from tr in Context.TreatmentRecords
                         .Include(a => a.Patient).ThenInclude(a => a.Address).Include(a => a.Hospital).ThenInclude(a => a.Address).Include(a => a.Disease)
                         .Include(a => a.Patient).ThenInclude(a => a.Occupation)
                         .Include(a => a.Patient).ThenInclude(a => a.Organisation).ThenInclude(a => a.Address)

                                    select new TreatmentRecordsDto()
                                    {
                                        TreatmentRecordsId = tr.TreatmentRecordsId,
                                        PatientID = tr.Patient.PatientID,
                                        PatientName = tr.Patient.PatientName,
                                        PAge = tr.Patient.PAge,
                                        PGender = tr.Patient.PGender,
                                        PEmail = tr.Patient.PEmail,
                                        AadharID = tr.Patient.AadharID,
                                        PContact = tr.Patient.PContact,

                                        AddressId = tr.Patient.Address.AddressId,
                                        AddressType = tr.Patient.Address.AddressType,
                                        StreetNo = tr.Patient.Address.StreetNo,
                                        Area = tr.Patient.Address.Area,
                                        City = tr.Patient.Address.City,
                                        State = tr.Patient.Address.State,
                                        Country = tr.Patient.Address.Country,
                                        ZipCode = tr.Patient.Address.ZipCode,

                                        OccupationId = tr.Patient.Occupation.OccupationId,
                                        OccupationName = tr.Patient.Occupation.OccupationName,
                                        OccupationType = tr.Patient.Occupation.OccupationType,

                                        OrganisationId = tr.Patient.Organisation.OrganisationId,
                                        OrganisationName = tr.Patient.Organisation.OrganisationName,
                                        OrganisationContact = tr.Patient.Organisation.OrganisationContact,

                                        Org_AddressId = tr.Patient.Organisation.Address.AddressId,
                                        Org_AddressType = tr.Patient.Organisation.Address.AddressType,
                                        Org_StreetNo = tr.Patient.Organisation.Address.StreetNo,
                                        Org_Area = tr.Patient.Organisation.Address.Area,
                                        Org_City = tr.Patient.Organisation.Address.City,
                                        Org_State = tr.Patient.Organisation.Address.State,
                                        Org_Country = tr.Patient.Organisation.Address.Country,
                                        Org_ZipCode = tr.Patient.Organisation.Address.ZipCode,


                                        HospitalId = tr.Hospital.HospitalId,
                                        HospitalName = tr.Hospital.HospitalName,
                                        Contact = tr.Hospital.Contact,

                                        Hos_AddressId = tr.Hospital.Address.AddressId,
                                        Hos_AddressType = tr.Hospital.Address.AddressType,
                                        Hos_StreetNo = tr.Hospital.Address.StreetNo,
                                        Hos_Area = tr.Hospital.Address.Area,
                                        Hos_City = tr.Hospital.Address.City,
                                        Hos_State = tr.Hospital.Address.State,
                                        Hos_Country = tr.Hospital.Address.Country,
                                        Hos_ZipCode = tr.Hospital.Address.ZipCode,

                                        DiseaseId = tr.Disease.DiseaseId,
                                        DiseaseName = tr.Disease.DiseaseName,
                                        DiseaseType = tr.Disease.DiseaseType,

                                        AdmittedDate = tr.AdmittedDate,
                                        Prescription = tr.Prescription,
                                        RelievingDate = tr.RelievingDate,
                                        IsFatal = tr.IsFatal,
                                        Currentstage = tr.Currentstage



                                    }).ToList();
            return treatmentrecords;
        }

        public List<TreatmentRecordsDto> GetCuredPatients()
        {
            var cured = (
                         from pat in Context.Patients 

                         join addr in Context.Addresses on pat.AddressId equals addr.AddressId
                         join tr in Context.TreatmentRecords on pat.PatientID equals tr.PatientID
                         
                         join hosp in Context.Hospitals on tr.HospitalId equals hosp.HospitalId
                         join disease in Context.Diseases on tr.DiseaseId equals disease.DiseaseId
                         where tr.Currentstage>=80


                         select new TreatmentRecordsDto()
                         {
                             PatientName = tr.Patient.PatientName,
                             AadharID = tr.Patient.AadharID, 
                             PContact = tr.Patient.PContact,
                             HospitalName = tr.Hospital.HospitalName,
                             City = tr.Patient.Address.City,
                             State = tr.Patient.Address.State,
                             AdmittedDate = tr.AdmittedDate,
                             Prescription = tr.Prescription,
                             RelievingDate = tr.RelievingDate,
                             IsFatal = tr.IsFatal,
                             Currentstage = tr.Currentstage

                         }).ToList();
            return cured;
        }

        public List<TreatmentRecordsDto> GetUnCuredPatients()
        {
            var uncured = (from pat in Context.Patients

                          join addr in Context.Addresses on pat.AddressId equals addr.AddressId
                          join tr in Context.TreatmentRecords on pat.PatientID equals tr.PatientID

                          join hosp in Context.Hospitals on tr.HospitalId equals hosp.HospitalId
                          join disease in Context.Diseases on tr.DiseaseId equals disease.DiseaseId
                          where tr.Currentstage<80 & tr.Currentstage!=0

                          select new TreatmentRecordsDto()
                           {
                               PatientName = tr.Patient.PatientName,
                               AadharID = tr.Patient.AadharID,
                               PContact = tr.Patient.PContact,
                               HospitalName = tr.Hospital.HospitalName,
                               City = tr.Patient.Address.City,
                               State = tr.Patient.Address.State,
                               AdmittedDate = tr.AdmittedDate,
                               Prescription = tr.Prescription,
                               RelievingDate = tr.RelievingDate,
                               IsFatal = tr.IsFatal,
                               Currentstage = tr.Currentstage

                           }).ToList();
            return uncured;
        }

        public List<TreatmentRecordsDto> GetDeceased()
        {
            var deceased = (from pat in Context.Patients

                            join addr in Context.Addresses on pat.AddressId equals addr.AddressId
                            join tr in Context.TreatmentRecords on pat.PatientID equals tr.PatientID

                            join hosp in Context.Hospitals on tr.HospitalId equals hosp.HospitalId
                            join disease in Context.Diseases on tr.DiseaseId equals disease.DiseaseId
                            where tr.Currentstage ==0
                            select new TreatmentRecordsDto()
                           {
                               PatientName = tr.Patient.PatientName,
                               AadharID = tr.Patient.AadharID,
                               PContact = tr.Patient.PContact,
                               HospitalName = tr.Hospital.HospitalName,
                               City = tr.Patient.Address.City,
                               State = tr.Patient.Address.State,
                               AdmittedDate = tr.AdmittedDate,
                               Prescription = tr.Prescription,
                               RelievingDate = tr.RelievingDate,
                               IsFatal = tr.IsFatal,
                               Currentstage = tr.Currentstage

                           }).ToList();
            return deceased;
        }

        public TreatmentRecords GetTreatmentRecords(int TreatmentRecordsId)
        {
            return Context.Set<TreatmentRecords>().Find(TreatmentRecordsId);
        }

        public TreatmentRecords Update(TreatmentRecords treatmentRecordsChanges)
        {
            var treatmentRecords = Context.TreatmentRecords.Attach(treatmentRecordsChanges);
            treatmentRecords.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return treatmentRecordsChanges;
        }
    }
}
