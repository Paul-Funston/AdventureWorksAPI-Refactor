using AdventureWorksAPI.Models;

namespace AdventureWorksAPI.Data
{
    public class AddressRepository : IAddressRepo
    {
        private AdventureWorksLt2019Context _context;
        public AddressRepository(AdventureWorksLt2019Context db)
        {
            _context = db;
        }

        public Address? GetAddress(int id)
        {
            return _context.Addresses.Find(id);
        }

        public ICollection<Address> GetAddresses()
        {
            return _context.Addresses.ToList();
        }
    }
}
