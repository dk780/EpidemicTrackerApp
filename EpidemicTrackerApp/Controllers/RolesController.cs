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
    public class RolesController : ControllerBase
    {
        private IRoleRepository roleRepository;
        public RolesController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }
        // GET: api/Roles
        [HttpGet]
        public IEnumerable<Role> GetAllRole() => roleRepository.GetAllRole();


        // GET: api/Roles/5
        [HttpGet("{RoleId}")]
        public Role GetRole(int RoleId) => roleRepository.GetRole(RoleId);


        // POST: api/Roles
        [HttpPost]
        public void AddRole([FromBody] Role role) => roleRepository.Add(role);


        // PUT: api/Roles/5
        [HttpPut("{RoleId}")]

        public void Put(int RoleId, [FromBody] Role role) => roleRepository.Update(role);


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{RoleId}")]
        public void DeleteRole(int RoleId) => roleRepository.Delete(RoleId);

    }
}

