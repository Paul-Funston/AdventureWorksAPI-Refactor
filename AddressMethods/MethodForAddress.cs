using AdventureWorksAPI.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Net;


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
                Address address = db.Addresses.Find(id);
                if(address == null)
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

        public static IResult Delete(AdventureWorksLt2019Context db, int id)
        {
            if(id == null)
            {
                return Results.BadRequest();
            }
            else
            {
                Address address = db.Addresses.Include(b => b.CustomerAddresses).ThenInclude(b => b.Customer).FirstOrDefault(b => b.AddressId == id);
                db.Addresses.Remove(address);
                db.SaveChanges();
                return Results.Ok();
            }
           
        }

        public static IResult Update(AdventureWorksLt2019Context db, int id, Address address)
        {

            Address addresses = db.Addresses.Find(id);

            if (addresses != null)
            {

                addresses.AddressId= id;
                addresses.AddressLine1 = address.AddressLine1;
                addresses.AddressLine2 = address.AddressLine2;
                addresses.City = address.City;
                addresses.CountryRegion = address.CountryRegion;
                addresses.PostalCode = address.PostalCode;
                addresses.ModifiedDate= address.ModifiedDate;
                addresses.Rowguid = address.Rowguid;
                addresses.StateProvince= address.StateProvince;
                db.SaveChanges();
                return Results.Ok(addresses);
            }
            else
            {
                db.Add(address);
                db.SaveChanges();
                return Results.Created($"address/details?id={address.AddressId}", address);
            }
        }
    }
}
