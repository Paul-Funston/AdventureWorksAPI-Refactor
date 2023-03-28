using AdventureWorksAPI.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace AdventureWorksAPI.AddressMethods
{
    public static class MethodForAddress
    {
        public static IResult GetAddress(AdventureWorksLt2019Context db, int? id)
        {
            if(id == null)
            {
                return Results.Ok(db.Addresses.ToList());
            }
            else
            {
                if(id == null)
                {
                    return Results.BadRequest();
                }
                else
                {
                    return Results.Ok(db.Addresses.Find(id));
                }
              
            }
            
        }
        public static IResult Create(AdventureWorksLt2019Context db, Address address)
        {
            db.Add(address);
            db.SaveChanges();
            return Results.Created($"address/details?id={address.AddressId}", address);
        }
    }
}
