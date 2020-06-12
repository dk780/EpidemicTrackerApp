using EpidemicTrackerApp.Dto;
using EpidemicTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Repositories
{
    public class OrganisationRepository : IOrganisationRepository
    {
        private readonly EpidemicTrackerAppDBContext Context;

        public OrganisationRepository(EpidemicTrackerAppDBContext context)
        {
            Context = context;

        }

        public OrganisationDto AddOrganisation(OrganisationDto organisationDto)
        {
            Address addr = new Address()
            {
                AddressId = organisationDto.AddressId,
                AddressType = organisationDto.AddressType,
                StreetNo = organisationDto.StreetNo,
                Area = organisationDto.Area,
                City = organisationDto.City,
                State = organisationDto.State,
                Country = organisationDto.Country,
                ZipCode = organisationDto.ZipCode,
            };
            Context.Addresses.Add(addr);
            Context.SaveChanges();
            int addressid = addr.AddressId;

            var organisations = new Organisation()
            {
                OrganisationId = organisationDto.OrganisationId,
                OrganisationName = organisationDto.OrganisationName,
                OrganisationContact = organisationDto.OrganisationContact,
                AddressId = addressid

            };
            Context.Organisations.Add(organisations);
            Context.SaveChanges();
            return organisationDto;

        }

        public Organisation Delete(int OrganisationId)
        {
            var organisation = Context.Set<Organisation>().Find(OrganisationId);
            if (organisation == null)
            {
                return organisation;
            }

            Context.Set<Organisation>().Remove(organisation);
            Context.SaveChanges();
            return organisation;
        }

        public List<OrganisationDto> GetAllOrganisation()
        {
            var organisations = (from org in Context.Organisations

                             .Include(a => a.Address)

                                 select new OrganisationDto()
                                 {

                                       OrganisationId= org.OrganisationId,
                                       OrganisationName= org.OrganisationName,
                                       OrganisationContact= org.OrganisationContact,

                                       AddressId = org.Address.AddressId,
                                       AddressType = org.Address.AddressType,
                                       StreetNo = org.Address.StreetNo,
                                       Area = org.Address.Area,
                                       City = org.Address.City,
                                       State = org.Address.State,
                                       Country = org.Address.Country,
                                       ZipCode = org.Address.ZipCode
                                       
                                 }).ToList();
            return organisations;
        }

        public List<OrganisationDto> GetOrganisation(int? OrganisationId)
        {
            if (Context != null)
            {
                var organisation = (from org in Context.Organisations
                                    
                                    join psnt in Context.Patients on org.PatientID equals psnt.PatientID

                                    select new OrganisationDto()
                                    {
                                        PatientID = psnt.PatientID,
                                        OrganisationId = org.OrganisationId,
                                        OrganisationName = org.OrganisationName,
                                        OrganisationContact = org.OrganisationContact,
                                        
                                    }).FirstOrDefault();
            }
                return null;
            }

        public Organisation Update(Organisation organisationChanges)
        {
            var organisation = Context.Organisations.Attach(organisationChanges);
            organisation.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return organisationChanges;
        }
    }
}
