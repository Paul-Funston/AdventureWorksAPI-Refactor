using AdventureWorksAPI.Models;
using NuGet.Protocol;
using System.Globalization;
using System.Net;

namespace AdventureWorksAPI.CustomerMethod
{
    public static class CustomerMethods
    {

        // READ: GetCustomers and GetCustomer
        public static IResult GetCustomers(AdventureWorksLt2019Context db, int? id, int maxResults = 100)
        {
            if(id == null)
            {
                return Results.Ok(db.Customers.Take(maxResults).ToList());
            } else
            {
                return Results.Ok(db.Customers.Where(c => c.CustomerId == id));
            }
        }

        // CREATE: CreateCustomer 
        public static IResult AddCustomer(AdventureWorksLt2019Context db, Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();

            return Results.Created($"/customer?id={customer.CustomerId}", customer);
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

        /*
            Customer/AddToAddress should take a Customer and Address Primary Key as properties, and create a new middle table object, defaulting to Main Office as the AddressType. 
        */

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
    }
}
