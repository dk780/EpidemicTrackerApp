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
    public class PatientsController : ControllerBase
    {
        private IPatientRepository patientRepository;
        public PatientsController(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }
        // GET: api/Patients
        [HttpGet]
        //public List<PatientDto> GetAllPatient() => patientRepository.GetAllPatient();

        public ActionResult GetAllPatient()
        {
            List<PatientDto> patients = new List<PatientDto>();
            patients = patientRepository.GetAllPatient();
            if (patients.Count == 0)
            {
                return NotFound();
            }
            return Ok(patients);
        }


        // GET: api/Patients/5
        [HttpGet("{PatientId}")]
        //public Patient GetPatient(int PatientId) => patientRepository.GetPatient(PatientId);
        public ActionResult GetPatient(int PatientId)
        {
            List<PatientDto> patient = new List<PatientDto>();
            patient = patientRepository.GetPatient(PatientId);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }


        // POST: api/Patients
        [HttpPost]
        //public void AddPatient([FromBody] Patient patient) => patientRepository.Add(patient);
        public ActionResult<PatientDto> PostPatient(PatientDto patientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            patientRepository.AddPatient(patientDto);
            return Ok("Added Successfully.");
        }


        // PUT: api/Patients/5
        [HttpPut("{PatientId}")]
        public void Put(int PatientId, [FromBody] Patient patient) => patientRepository.Update(patient);


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{PatientId}")]
        public void DeletePatient(int PatientId) => patientRepository.Delete(PatientId);

    }
}
