using EpidemicTrackerApp.Dto;
using EpidemicTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Repositories
{
    public interface IOrganisationRepository
    {
        List<OrganisationDto> GetOrganisation(int? OrganisationId);
        List<OrganisationDto> GetAllOrganisation();

        OrganisationDto AddOrganisation(OrganisationDto organisationDto);

        Organisation Update(Organisation organisationChanges);
        Organisation Delete(int OrganisationId);
    }
}
