using AdventureWorksAPI.Models;

namespace AdventureWorksAPI.Data
{
    public interface IAddressRepo
    {
        public Address? GetAddress(int id);

        public ICollection<Address> GetAddresses(); 
    }
}
