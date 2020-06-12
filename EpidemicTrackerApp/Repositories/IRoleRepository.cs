using EpidemicTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Repositories
{
    public interface IRoleRepository
    {
        Role GetRole(int RoleId);
        IEnumerable<Role> GetAllRole();

        Role Add(Role role);

        Role Update(Role roleChanges);
        Role Delete(int RoleId);
    }
}
