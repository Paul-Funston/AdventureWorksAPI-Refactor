using AdventureWorksAPI.Models;

namespace AdventureWorksAPI.Data
{
    public class CustomerRepo : ICustomerRepo
    {
        
        private AdventureWorksLt2019Context _context;
        public CustomerRepo(AdventureWorksLt2019Context context)
        {
            _context = context;
        }
        public ICollection<Customer> GetCustomers() 
        {
            return _context.Customers.ToList();
        }
        public Customer GetCustomer(int id)
        {
            return _context.Customers.Find(id);
        }

        public int CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer.CustomerId;
        }
        public void UpdateCustomer(int id, Customer customer)
        {
            Customer updatingCustomer = _context.Customers.Find(id);

            if (updatingCustomer == null)
            {
                _context.Customers.Add(customer);

                _context.SaveChanges();
            } 
        }
        
    }
}
