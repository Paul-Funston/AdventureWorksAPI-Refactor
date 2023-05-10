using AdventureWorksAPI.Models;

namespace AdventureWorksAPI.Data
{
    public interface ICustomerRepo
    {
        public ICollection<Customer> GetCustomers();
        public Customer GetCustomer(int id);
        public int CreateCustomer(Customer customer);
        public void UpdateCustomer(int id, Customer customer);
        public void DeleteCustomer(Customer customer);

    }
}
