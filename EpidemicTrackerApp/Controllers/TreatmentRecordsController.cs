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
    public class TreatmentRecordsController : ControllerBase
    {
        private ITreatmentRecordsRepository treatmentRecordsRepository;
        public TreatmentRecordsController(ITreatmentRecordsRepository treatmentRecordsRepository)
        {
            this.treatmentRecordsRepository = treatmentRecordsRepository;
        }
        // GET: api/TreatmentRecords
        [HttpGet]
        //public IEnumerable<TreatmentRecords> GetAllTreatmentRecords() => treatmentRecordsRepository.GetAllTreatmentRecords();
        public ActionResult GetAlltreatmentRecords()
        {
            List<TreatmentRecordsDto> treatmentRecords = new List<TreatmentRecordsDto>();
            treatmentRecords = treatmentRecordsRepository.GetAllTreatmentRecords();
            if (treatmentRecords.Count == 0)
            {
                return NotFound();
            }
            return Ok(treatmentRecords);
        }

        [HttpGet]
        [Route("GetCuredPatients")]
        public ActionResult GetCuredPatients()
        {
            List<TreatmentRecordsDto> curedpatients = new List<TreatmentRecordsDto>();
            curedpatients = treatmentRecordsRepository.GetAllTreatmentRecords();
            if (curedpatients.Count == 0)
            {
                return NotFound();
            }
            return Ok(curedpatients);
        }
        [HttpGet]
        [Route("GetUnCuredPatients")]
        public ActionResult GetUnCuredPatients()
        {
            List<TreatmentRecordsDto> uncuredpatients = new List<TreatmentRecordsDto>();
            uncuredpatients = treatmentRecordsRepository.GetAllTreatmentRecords();
            if (uncuredpatients.Count == 0)
            {
                return NotFound();
            }
            return Ok(uncuredpatients);
        }

        [HttpGet]
        [Route("GetDeceased")]
        public ActionResult GetDeceased()
        {
            List<TreatmentRecordsDto> deceased = new List<TreatmentRecordsDto>();
            deceased = treatmentRecordsRepository.GetAllTreatmentRecords();
            if (deceased.Count == 0)
            {
                return NotFound();
            }
            return Ok(deceased);
        }


        // GET: api/TreatmentRecords/5
        [HttpGet("{TreatmentRecordsId}")]
        public TreatmentRecords GetTreatmentRecords(int TreatmentRecordsId) => treatmentRecordsRepository.GetTreatmentRecords(TreatmentRecordsId);


        // POST: api/TreatmentRecords
        [HttpPost]
        //public void AddTreatmentRecords([FromBody] TreatmentRecords treatmentRecords) => treatmentRecordsRepository.Add(treatmentRecords);
        public ActionResult<TreatmentRecordsDto> PostTreatmentRecords(TreatmentRecordsDto treatmentRecordsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            treatmentRecordsRepository.AddTreatmentRecords(treatmentRecordsDto);
            return Ok("Added Successfully.");
        }


        // PUT: api/TreatmentRecords/5
        [HttpPut("{TreatmentRecordsId}")]
        public void Put(int TreatmentRecordsId, [FromBody] TreatmentRecords treatmentRecords) => treatmentRecordsRepository.Update(treatmentRecords);


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{TreatmentRecordsId}")]
        public void DeleteTreatmentRecords(int TreatmentRecordsId) => treatmentRecordsRepository.Delete(TreatmentRecordsId);

    }
}
