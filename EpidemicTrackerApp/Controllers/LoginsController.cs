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
    public class LoginsController : ControllerBase
    {
        private ILoginRepository loginRepository;
        public LoginsController(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }
        // GET: api/Logins
        [HttpGet]

        public ActionResult GetAllLogin()
        {
            List<LoginDto> logins = new List<LoginDto>();
            logins = loginRepository.GetAllLogin();
            if (logins.Count == 0)
            {
                return NotFound();
            }
            return Ok(logins);
        }
        [HttpGet("GetLogin")]
        public ActionResult GetLogin(int LoginId)
        {
            LoginDto login = new LoginDto();
            login = loginRepository.GetLogin(LoginId);
            if (login == null)
            {
                return NotFound();
            }
            return Ok(login);
        }



        // POST: api/Logins
        [HttpPost]
        //public void AddLogin([FromBody] Login login) => loginRepository.Add(login);
        public ActionResult<LoginDto> PostLogin(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            loginRepository.AddLogin(loginDto);
            return Ok("Added Successfully.");
        }

        // PUT: api/Logins/5
        [HttpPut("{LoginId}")]

        public void Put(int LoginId, [FromBody] Login login) => loginRepository.Update(login);


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{LoginId}")]
        public void DeleteLogin(int LoginId) => loginRepository.Delete(LoginId);
    }
}
