using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicTrackerApp.Dto;
using EpidemicTrackerApp.Models;
using EpidemicTrackerApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EpidemicTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisationsController : ControllerBase
    {
        private IOrganisationRepository organisationRepository;
        public OrganisationsController(IOrganisationRepository organisationRepository)
        {
            this.organisationRepository = organisationRepository;
        }
        // GET: api/Organisations
        [HttpGet]
        //public IEnumerable<Organisation> GetAllOrganisation() => organisationRepository.GetAllOrganisation();
        public ActionResult GetAllOrganisation()
        {
            List<OrganisationDto> organisations = new List<OrganisationDto>();
            organisations = organisationRepository.GetAllOrganisation();
            if (organisations.Count == 0)
            {
                return NotFound();
            }
            return Ok(organisations);
        }

        // GET: api/Organisations/5
        [HttpGet("{OrganisationId}")]
        //public Organisation GetOrganisation(int OrganisationId) => organisationRepository.GetOrganisation(OrganisationId);
        public ActionResult GetOrganisation(int OrganisationId)
        {
            List<OrganisationDto> organisation = new List<OrganisationDto>();
            organisation = organisationRepository.GetOrganisation(OrganisationId);
            if (organisation == null)
            {
                return NotFound();
            }
            return Ok(organisation);
        }

        // POST: api/Organisations
        [HttpPost]
        //public void AddOrganisation([FromBody] Organisation organisation) => organisationRepository.Add(organisation);
        public ActionResult<OrganisationDto> PostOrganisation(OrganisationDto organisationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            organisationRepository.AddOrganisation(organisationDto);
            return Ok("Added Successfully.");
        }


        // PUT: api/Organisations/5
        [HttpPut("{id}")]
        public void Put(int OrganisationId, [FromBody] Organisation organisation) => organisationRepository.Update(organisation);


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteOrganisation(int OrganisationId) => organisationRepository.Delete(OrganisationId);

    }
}

