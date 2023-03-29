using AdventureWorksAPI.Models;

namespace AdventureWorksAPI.Product
{
    public static class ProductMethod
    {
        public static IResult GetProduct(AdventureWorksLt2019Context db, int productID)
        {
            var product = db.Products.Where(p => p.ProductId == productID).FirstOrDefault();
            if (product == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(product);
        }
    }

}
