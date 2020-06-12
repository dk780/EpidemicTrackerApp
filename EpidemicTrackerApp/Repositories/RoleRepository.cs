using EpidemicTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly EpidemicTrackerAppDBContext Context;

        public RoleRepository(EpidemicTrackerAppDBContext context)
        {
            Context = context;

        }

        public Role Add(Role role)
        {
            Context.Set<Role>().Add(role);
            Context.SaveChanges();
            return role;
        }

        public Role Delete(int RoleId)
        {
            var role = Context.Set<Role>().Find(RoleId);
            if (role == null)
            {
                return role;
            }

            Context.Set<Role>().Remove(role);
            Context.SaveChanges();
            return role;
        }

        public IEnumerable<Role> GetAllRole()
        {
            return Context.Set<Role>().ToList();
        }

        public Role GetRole(int RoleId)
        {
            return Context.Set<Role>().Find(RoleId);
        }

        public Role Update(Role roleChanges)
        {
            var role = Context.Roles.Attach(roleChanges);
            role.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return roleChanges;




        }
    }
}
