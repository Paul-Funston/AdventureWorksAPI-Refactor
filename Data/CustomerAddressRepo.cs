using AdventureWorksAPI.Models;

namespace AdventureWorksAPI.Data
{
    public class CustomerAddressRepo : ICustomerAddressRepo
    {
        private AdventureWorksLt2019Context _context;

        public CustomerAddressRepo(AdventureWorksLt2019Context context)
        {
            _context = context;
        }

        public ICollection<CustomerAddress> GetCustomerAddresses()
        {
            return _context.CustomerAddresses.ToList();
        }


    }
}
