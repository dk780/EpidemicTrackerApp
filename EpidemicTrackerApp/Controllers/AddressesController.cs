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
    public class AddressesController : ControllerBase
    {
        private IAddressRepository addressRepository;
        public AddressesController(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }
        // GET: api/Occupations
        [HttpGet]

        public IEnumerable<Address> GetAllAddress() => addressRepository.GetAllAddress();

        // GET: api/Occupations/5
        [HttpGet("{AddressId}")]
        public Address GetAddress(int AddressId) => addressRepository.GetAddress(AddressId);

        // POST: api/Addresses
        [HttpPost]
        public void AddAddress([FromBody] Address address) => addressRepository.Add(address);

        // PUT: api/Addresses/5
        [HttpPut("{AddressId}")]
        public void Put(int AddressId, [FromBody] Address address) => addressRepository.Update(address);

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{AddressId}")]
        public void DeleteAddress(int AddressId) => addressRepository.Delete(AddressId);

    }
}
