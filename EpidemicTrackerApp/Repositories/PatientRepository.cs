using EpidemicTrackerApp.Dto;
using EpidemicTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly EpidemicTrackerAppDBContext Context;

        public PatientRepository(EpidemicTrackerAppDBContext context)
        {
            Context = context;

        }

        public PatientDto AddPatient(PatientDto patientDto)
        {
                     

            var pat = new Patient()
            {
                PatientID = patientDto.PatientID,
                PatientName = patientDto.PatientName,
                PAge = patientDto.PAge,
                PGender = patientDto.PGender,
                PEmail = patientDto.PEmail,
                PContact = patientDto.PContact,
                AadharID = patientDto.AadharID,

            };

            Context.Patients.Add(pat);
            Context.SaveChanges();
            int patientID = pat.PatientID;

            Address addr = new Address()
            {
                AddressId = patientDto.AddressId,
                AddressType = patientDto.AddressType,
                StreetNo = patientDto.StreetNo,
                Area = patientDto.Area,
                City = patientDto.City,
                State = patientDto.State,
                Country = patientDto.Country,
                ZipCode = patientDto.ZipCode,
            };
            Context.Addresses.Add(addr);
            Context.SaveChanges();

            Occupation ocp = new Occupation()
            {
                OccupationId = patientDto.OccupationId,
                OccupationName = patientDto.OccupationName,
                OccupationType = patientDto.OccupationType,
                PatientID = patientID
            };
            Context.Occupations.Add(ocp);
            Context.SaveChanges();

            Organisation organ = new Organisation()
            {
                OrganisationId = patientDto.OrganisationId,
                OrganisationName = patientDto.OrganisationName,
                OrganisationContact = patientDto.OrganisationContact,
                PatientID = patientID
            };
            Context.Organisations.Add(organ);
            Context.SaveChanges();
            
            

            return patientDto;
        }

        public Patient Delete(int PatientId)
        {
            var patient = Context.Set<Patient>().Find(PatientId);
            if(patient== null)
            {
                return patient;
            }

            Context.Set<Patient>().Remove(patient);
            Context.SaveChanges();
            return patient;
        }

        public List<PatientDto> GetAllPatient()
        {

            var patients = (from psnt in Context.Patients
                           .Include(a => a.Address).Include(a => a.Occupation).Include(a => a.Organisation)

                            select new PatientDto()
                            {
                                PatientID = psnt.PatientID,
                                PatientName = psnt.PatientName,
                                PAge = psnt.PAge,
                                PGender = psnt.PGender,
                                PEmail = psnt.PEmail,
                                AadharID = psnt.AadharID,
                                PContact = psnt.PContact,

                                AddressId = psnt.Address.AddressId,
                                AddressType = psnt.Address.AddressType,
                                StreetNo = psnt.Address.StreetNo,
                                Area = psnt.Address.Area,
                                City = psnt.Address.City,
                                State = psnt.Address.State,
                                Country = psnt.Address.Country,
                                ZipCode = psnt.Address.ZipCode,

                                OccupationId = psnt.Occupation.OccupationId,
                                OccupationName = psnt.Occupation.OccupationName,
                                OccupationType = psnt.Occupation.OccupationType,

                                OrganisationId = psnt.Organisation.OrganisationId,
                                OrganisationName = psnt.Organisation.OrganisationName,
                                OrganisationContact = psnt.Organisation.OrganisationContact
                                


                            }).ToList();
            return patients;
        }

        public List<PatientDto> GetPatient(int? PatientId)
        {
            if(Context != null)
            {
                var patients = (from psnt in Context.Patients
                           .Include(a => a.Address).Include(a => a.Occupation).Include(a => a.Organisation)

                                select new PatientDto()
                                {
                                    PatientID = psnt.PatientID,
                                    PatientName = psnt.PatientName,
                                    PAge = psnt.PAge,
                                    PGender = psnt.PGender,
                                    PEmail = psnt.PEmail,
                                    PContact = psnt.PContact,

                                    AddressId = psnt.Address.AddressId,
                                    AddressType = psnt.Address.AddressType,
                                    StreetNo = psnt.Address.StreetNo,
                                    Area = psnt.Address.Area,
                                    City = psnt.Address.City,
                                    State = psnt.Address.State,
                                    Country = psnt.Address.Country,
                                    ZipCode = psnt.Address.ZipCode,


                                    OccupationId = psnt.Occupation.OccupationId,
                                    OccupationName = psnt.Occupation.OccupationName,
                                    OccupationType = psnt.Occupation.OccupationType,

                                    OrganisationId = psnt.Organisation.OrganisationId,
                                    OrganisationName = psnt.Organisation.OrganisationName,
                                    OrganisationContact = psnt.Organisation.OrganisationContact



                                }).FirstOrDefault();
            }
            return null;
        }

        public Patient Update(Patient patientChanges)
        {
            var patient = Context.Patients.Attach(patientChanges);
            patient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return patientChanges;
        }
    }
}
