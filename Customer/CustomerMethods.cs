using AdventureWorksAPI.Models;

namespace AdventureWorksAPI.Customer
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

        // CREATE: CreateCustomer method



    }
}
