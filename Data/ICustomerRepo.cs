using AdventureWorksAPI.Models;

namespace AdventureWorksAPI.Data
{
    public interface ICustomerRepo
    {
        public ICollection<Customer> GetCustomers();
        public Customer GetCustomer(int id);
        public void CreateCustomer(Customer customer);
       



    }
}
