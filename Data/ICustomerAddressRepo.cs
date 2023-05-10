using AdventureWorksAPI.Models;

namespace AdventureWorksAPI.Data
{
    public interface ICustomerAddressRepo
    {
        public ICollection<CustomerAddress> GetCustomerAddresses();
    }
}
