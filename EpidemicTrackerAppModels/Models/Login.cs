using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Models
{
    public class Login
    {
        public int LoginId { get; set; }

 
        public string Name { get; set; }

        public string Gender { get; set; }

  
        public string Email { get; set; }

        public string Contact { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
