using EpidemicTrackerApp.Dto;
using EpidemicTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Repositories
{
    public class HospitalRepository :IHospitalRepository
    {
        private readonly EpidemicTrackerAppDBContext Context;

        public HospitalRepository(EpidemicTrackerAppDBContext context)
        {
            Context = context;

        }

        public HospitalDto AddHospital(HospitalDto hospitalDto)
        {
            
            

            var hospitals = new Hospital()
            {
                HospitalId = hospitalDto.HospitalId,

                HospitalName = hospitalDto.HospitalName,
                Contact = hospitalDto.Contact,

            };
            Context.Hospitals.Add(hospitals);
            Context.SaveChanges();
            int hospitalId = hospitals.HospitalId;

            Address addr = new Address()
            {
                AddressId = hospitalDto.AddressId,
                AddressType = hospitalDto.AddressType,
                StreetNo = hospitalDto.StreetNo,
                Area = hospitalDto.Area,
                City = hospitalDto.City,
                State = hospitalDto.State,
                Country = hospitalDto.Country,
                ZipCode = hospitalDto.ZipCode,

            };
            Context.Addresses.Add(addr);
            Context.SaveChanges();


            return hospitalDto;

        }

        public void Delete(int HospitalId)
        {
            var hospital = Context.Hospitals.Where(c => c.HospitalId == HospitalId).FirstOrDefault();
            Context.Entry(hospital).State = EntityState.Deleted;
            Context.SaveChanges();
        }

        public List<HospitalDto> GetAllHospital()
        {

            var hospitals = (from hosp in Context.Hospitals
                             .Include(a => a.Address)

                            select new HospitalDto()
                            {
                                HospitalId = hosp.HospitalId,
                                HospitalName = hosp.HospitalName,
                                Contact = hosp.Contact,
                                

                                AddressId = hosp.Address.AddressId,
                                AddressType = hosp.Address.AddressType,
                                StreetNo = hosp.Address.StreetNo,
                                Area = hosp.Address.Area,
                                City = hosp.Address.City,
                                State = hosp.Address.State,
                                Country = hosp.Address.Country,
                                ZipCode = hosp.Address.ZipCode


                            }).ToList();
            return hospitals;
        }

        public List<HospitalDto> GetHospital(int? HospitalId)
        {
            if(Context != null)
            {
            }
            return null;
        }

        public Hospital Put(Hospital hospitalChanges)
        {
            var hospital = Context.Hospitals.Attach(hospitalChanges);
            hospital.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return hospitalChanges;
        }
    }
}
