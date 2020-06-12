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
    public class DiseasesController : ControllerBase
    {
        private readonly IDiseaseRepository diseaseRepository;

        public DiseasesController(IDiseaseRepository diseaseRepository)
        {
            this.diseaseRepository = diseaseRepository;
        }
        // GET: api/Diseases
        [HttpGet]
        //public IEnumerable<Disease> GetAllDisease() => diseaseRepository.GetAllDisease();
        public IEnumerable<DiseaseDto> GetAllDisease()
        {
            var diseasefromRepo = diseaseRepository.GetAllDisease();
            var disDto = new List<DiseaseDto>();
            foreach (var disease in diseasefromRepo)
            {
                disDto.Add(new DiseaseDto()
                {
                    DiseaseId = disease.DiseaseId,
                    DiseaseName = disease.DiseaseName,
                    DiseaseType = disease.DiseaseType
                });

            }
            return disDto;
        }


        // GET: api/Diseases/5
        [HttpGet("{DiseaseId}")]
        public Disease GetDisease(int DiseaseId) => diseaseRepository.GetDisease(DiseaseId);


        // POST: api/Diseases
        [HttpPost]
        public void AddDisease([FromBody] Disease disease) => diseaseRepository.Add(disease);



        // PUT: api/Diseases/5
        [HttpPut("{DiseaseId}")]
        public void Put(int DiseaseId, [FromBody] Disease disease) => diseaseRepository.Update(disease);




        // DELETE: api/ApiWithActions/5
        [HttpDelete("{DiseaseId}")]
        public void DeleteDisease(int DiseaseId) => diseaseRepository.Delete(DiseaseId);


    }
}

