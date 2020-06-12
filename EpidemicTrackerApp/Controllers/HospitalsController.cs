using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidemicTrackerApp.Dto;
using EpidemicTrackerApp.Models;
using EpidemicTrackerApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EpidemicTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly IHospitalRepository hospitalRepository;
        public HospitalsController(IHospitalRepository hospitalRepository)
        {
            this.hospitalRepository = hospitalRepository;
        }
        // GET: api/Hospitals
        [HttpGet]
        //public IEnumerable<Hospital> GetAllHospital() => hospitalRepository.GetAllHospital();
        public ActionResult GetAllHospital()
        {
            List<HospitalDto> hospitals = new List<HospitalDto>();
            hospitals = hospitalRepository.GetAllHospital();
            if (hospitals.Count == 0)
            {
                return NotFound();
            }
            return Ok(hospitals);
        }



        // GET: api/Hospitals/5
        [HttpGet("{HospitalId}")]
        //public Hospital GetHospital(int HospitalId) => hospitalRepository.GetHospital(HospitalId);
        public ActionResult GetHospital(int HospitalId)
        {
            List<HospitalDto> hospital = new List<HospitalDto>();
            hospital = hospitalRepository.GetHospital(HospitalId);
            if (hospital == null)
            {
                return NotFound();
            }
            return Ok(hospital);
        }


        // POST: api/Hospitals
        [HttpPost]
        //public void AddHospital([FromBody] Hospital hospital) => hospitalRepository.Add(hospital);
        public ActionResult<HospitalDto> PostHospital(HospitalDto hospitalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            hospitalRepository.AddHospital(hospitalDto);
            return Ok("Success");
        }


        // PUT: api/Hospitals/5
        [HttpPut("{HospitalId}")]
        //public void Put(int HospitalId, [FromBody] Hospital hospital) => hospitalRepository.Update(hospital);
        public ActionResult Put(int HospitalId, [FromBody]Hospital hospital)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            if (HospitalId > 0)
            {
                hospitalRepository.Put(hospital);
                return Ok("Success");
            }
            return NotFound();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{DiseaseId}")]
        //public void DeleteHospital(int HospitalId) => hospitalRepository.Delete(HospitalId);
        public ActionResult Delete(int HospitalId)
        {
            if (HospitalId <= 0)
                return BadRequest("Nothing found");
            hospitalRepository.Delete(HospitalId);
            return Ok("Success");

        }
    }
}
