using AdventureWorksAPI.Models;
using System.Globalization;
using System.Net;

namespace AdventureWorksAPI.CustomerMethod
{
    public static class CustomerMethods
    {

        // READ: GetCustomers and GetCustomer
        public static IResult GetCustomers(AdventureWorksLt2019Context db, int maxResults = 100)
        {
            return Results.Ok(db.Customers.Take(maxResults).ToList());
        }

        public static IResult GetCustomer(AdventureWorksLt2019Context db, int id)
        {
            return Results.Ok(db.Customers.Where(c => c.CustomerId == id));
        }

        // CREATE: CreateCustomer 
        public static IResult AddCustomer(AdventureWorksLt2019Context db, Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();

            return Results.Created($"/customer?id={customer.CustomerId}", customer);
        }


    }
}
