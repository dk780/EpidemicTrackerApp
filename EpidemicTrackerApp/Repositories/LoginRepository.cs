using EpidemicTrackerApp.Dto;
using EpidemicTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly EpidemicTrackerAppDBContext Context;

        public LoginRepository(EpidemicTrackerAppDBContext context)
        {
            Context = context;

        }

        public LoginDto AddLogin(LoginDto loginDto)
        {
            Role rol = new Role()
            {
                RoleName = loginDto.RoleName
            };

            Context.Roles.Add(rol);
            Context.SaveChanges();
            int roleid = rol.RoleId;

            var logins = new Login()
            {
                LoginId = loginDto.LoginId,
                Name = loginDto.Name,
                Gender = loginDto.Gender,
                Email = loginDto.Email,
                Contact = loginDto.Contact,
                Password = loginDto.Password,
                ConfirmPassword = loginDto.Password,
                RoleId = roleid

            };
            Context.Logins.Add(logins);
            Context.SaveChanges();
            return loginDto;
        }

        public Login Delete(int LoginId)
        {
            var login = Context.Set<Login>().Find(LoginId);
            if (login == null)
            {
                return login;
            }

            Context.Set<Login>().Remove(login);
            Context.SaveChanges();
            return login;
        }

        public List<LoginDto> GetAllLogin()
        {
                var logins = (from log in Context.Logins
                                .Include(a => a.Role)
                                select new LoginDto()
                                {
                                    LoginId= log.LoginId,
                                    Name= log.Name,
                                    Gender= log.Gender,
                                    Email = log.Email,
                                    Contact = log.Contact,
                                    Password= log.Password,
                                    ConfirmPassword= log.ConfirmPassword,
                                    RoleName = log.Role.RoleName

                                }).ToList();
                return logins;
            }
        

        public LoginDto GetLogin(int LoginId)
        {
            return Context.Set<LoginDto>().Find(LoginId);
        }

        public Login Update(Login loginChanges)
        {
            var login = Context.Logins.Attach(loginChanges);
            login.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return loginChanges;
        }
    }
}
