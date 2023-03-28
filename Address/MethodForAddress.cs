using AdventureWorksAPI.Models;
using System.Linq;

namespace AdventureWorksAPI.Address
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
                return Results.Ok(db.Addresses.Find(id));
            }
            
        }
    }
}
