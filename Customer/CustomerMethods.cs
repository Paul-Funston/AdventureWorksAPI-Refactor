using AdventureWorksAPI.Models;

namespace AdventureWorksAPI.Customer
{
    public static class CustomerMethods
    {
        public static IResult GetCustomers(AdventureWorksLt2019Context db, int maxResults = 100)
        {
            return Results.Ok(db.Products.Take(maxResults).ToList());
        }
    }
}
