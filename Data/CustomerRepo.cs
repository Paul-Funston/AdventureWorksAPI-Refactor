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

            updatingCustomer.Title = customer.Title;
            updatingCustomer.FirstName = customer.FirstName;
            updatingCustomer.MiddleName = customer.MiddleName;
            updatingCustomer.LastName = customer.LastName;
            updatingCustomer.Suffix = customer.Suffix;
            updatingCustomer.CompanyName = customer.CompanyName;
            updatingCustomer.SalesPerson = customer.SalesPerson;
            updatingCustomer.EmailAddress = customer.EmailAddress;
            updatingCustomer.Phone = customer.Phone;
            updatingCustomer.ModifiedDate = customer.ModifiedDate;

            _context.SaveChanges();

            
        }
        public void DeleteCustomer(Customer customer)
        {
            
            _context.Customers.Remove(customer);

            _context.SaveChanges();

        }


    }
}
