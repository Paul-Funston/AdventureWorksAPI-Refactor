using AdventureWorksAPI.Models;
using NuGet.Protocol;
using System.Globalization;
using System.Net;
using AdventureWorksAPI.Data;

namespace AdventureWorksAPI.CustomerMethod
{
    public static class CustomerMethods
    {

        // READ: GetCustomers and GetCustomer
        public static IResult GetCustomers(ICustomerRepo Repo, int? id, int maxResults = 100)
        {
            if(id == null)
            {
                return Results.Ok(Repo.GetCustomers());
            } else
            {
                return Results.Ok(Repo.GetCustomer((int)id));
            }
        }

        // CREATE: CreateCustomer 
        public static IResult AddCustomer(ICustomerRepo Repo, Customer customer)
        {
            int id = Repo.CreateCustomer(customer);

            Repo.CreateCustomer(customer);

            Customer createdCustomer = Repo.GetCustomer(id);

            return Results.Created($"/customer?id={id}", createdCustomer);
        }

        // UPDATE: UpdateCustomer
        public static IResult UpdateCustomer(AdventureWorksLt2019Context db, int id, Customer customer)
        {
            Customer updatingCustomer = db.Customers.Find(id);

            if(updatingCustomer == null)
            {
                db.Customers.Add(customer);
                db.SaveChanges();

                return Results.Created($"/customer?id={customer.CustomerId}", customer);
            } else
            {
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

                db.SaveChanges();
                return Results.Ok();
            }
        }

        // DELETE: DeleteCustomer
        public static IResult DeleteCustomer(AdventureWorksLt2019Context db, int id)
        {
            Customer customer = db.Customers.Find(id);

            if (customer == null)
            {
                return Results.BadRequest();
            }
            else
            {
                db.Customers.Remove(customer);
                db.SaveChanges();

                return Results.Ok();
            }
        }

        public static IResult AddCustomerToAddress(AdventureWorksLt2019Context db, int CustomerId, int AddressId)
        {
            Customer customer = db.Customers.First(c => c.CustomerId == CustomerId);
            Address address = db.Addresses.First(a => a.AddressId == AddressId);
            CustomerAddress customerAddress = new CustomerAddress();

            if (customer != null || address != null)
            {
                customerAddress.CustomerId = CustomerId;
                customerAddress.AddressId = AddressId;
                customerAddress.AddressType = "Main Office";
                customerAddress.Rowguid = new Guid();
                customerAddress.ModifiedDate = DateTime.Now;

                db.CustomerAddresses.Add(customerAddress);
                db.SaveChanges();
                return Results.Ok();
            }

            return Results.BadRequest();
        }

        /*
            Customer/Details<PrimaryKey> and Address/Details<PrimaryKey> should also list their related Customers/Addresses using the CustomerAddress middle table in the returned JSON. 
        */

        public static IResult FindAddressesInCustomer(AdventureWorksLt2019Context db, int id)
        {
            Customer customer = db.Customers.Find(id);

            if(customer != null) 
            {
                List<CustomerAddress> customerAddresses = db.CustomerAddresses.Where(ca => ca.CustomerId == id).ToList();

                List<Address> addresses = db.Addresses.Where(a => a.CustomerAddresses.Any(ca => ca.CustomerId == id)).ToList();

                var obj = new
                {
                    Address = addresses.Select(a => new { a.AddressId, a.AddressLine1, a.AddressLine2, a.City, a.CountryRegion }),
                    Customer = new { customer.CustomerId, customer.Title, customer.FirstName, customer.MiddleName, customer.LastName }
                };

                return Results.Ok(obj);
            }

            return Results.BadRequest();
        }
    }
}
