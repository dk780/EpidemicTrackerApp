using EpidemicTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTrackerApp.Repositories
{
    public interface IAddressRepository
    {
        Address GetAddress(int AddressId);
        IEnumerable<Address> GetAllAddress();

        Address Add(Address address);

        Address Update(Address addressChanges);
        Address Delete(int addressId);
    }
}
