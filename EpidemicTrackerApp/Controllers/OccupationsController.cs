using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicTrackerApp.Models;
using EpidemicTrackerApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EpidemicTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationsController : ControllerBase
    {
        private IOccupationRepository occupationRepository;
        public OccupationsController(IOccupationRepository occupationRepository)
        {
            this.occupationRepository = occupationRepository;
        }
        // GET: api/Occupations
        [HttpGet]

        public IEnumerable<Occupation> GetAllOccupation() => occupationRepository.GetAllOccupation();

        // GET: api/Occupations/5
        [HttpGet("{OccupationId}")]
        public Occupation GetOccupation(int OccupationId) => occupationRepository.GetOccupation(OccupationId);

        // POST: api/Occupations
        [HttpPost]
        public void AddOccupation([FromBody] Occupation occupation) => occupationRepository.Add(occupation);

        // PUT: api/Occupations/5
        [HttpPut("{OccupationId}")]
        public void Put(int OccupationId, [FromBody] Occupation occupation) => occupationRepository.Update(occupation);

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{OccupationId}")]
        public void DeleteOccupation(int OccupationId) => occupationRepository.Delete(OccupationId);

    }
}

