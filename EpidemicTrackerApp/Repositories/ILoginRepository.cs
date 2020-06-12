using EpidemicTrackerApp.Dto;
using EpidemicTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Repositories
{
    public interface ILoginRepository
    {
        LoginDto GetLogin(int LoginId);
        List<LoginDto> GetAllLogin();

        LoginDto AddLogin(LoginDto loginDto);

        Login Update(Login loginChanges);
        Login Delete(int LoginId);
    }
}
