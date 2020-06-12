using EpidemicTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly EpidemicTrackerAppDBContext Context;

        public AddressRepository(EpidemicTrackerAppDBContext context)
        {
            Context = context;

        }

        public Address Add(Address address)
        {
            Context.Set<Address>().Add(address);
            Context.SaveChanges();
            return address;
        }

        public Address Delete(int addressId)
        {
            var address = Context.Set<Address>().Find(addressId);
            if (address == null)
            {
                return address;
            }

            Context.Set<Address>().Remove(address);
            Context.SaveChanges();
            return address;
        }

        public IEnumerable<Address> GetAllAddress()
        {
            return Context.Set<Address>().ToList();
        }

        public Address GetAddress(int AddressId)
        {
            return Context.Set<Address>().Find(AddressId);
        }

        public Address Update(Address addressChanges)
        {
            var address = Context.Addresses.Attach(addressChanges);
            address.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return addressChanges;
        }
    }
}
