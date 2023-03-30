using AdventureWorksAPI.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
 
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public static IResult AddProduct(AdventureWorksLt2019Context db, AdventureWorksAPI.Models.Product product)
        {
            //test json : {"Name":"aaa","ProductNumber":"dddd"}
            product.SellStartDate = DateTime.Now;
            product.Rowguid = System.Guid.NewGuid();
            product.ModifiedDate = System.DateTime.Now;

            db.Products.Add(product);
            db.SaveChanges();

            return Results.Ok();

        }
        public static IResult UpdateProduct(AdventureWorksLt2019Context db, AdventureWorksAPI.Models.Product product)
        {
            //test json: {"ProductId":1000,"Name":"test"}"

            AdventureWorksAPI.Models.Product? findedProduct = db.Products.Find(product.ProductId);

            if (findedProduct == null)
            {
                return Results.NotFound(product.ProductId);
            }

            findedProduct.Name = product.Name;
            db.SaveChanges();

            return Results.Ok();

        }
        public static IResult DeleteProduct(AdventureWorksLt2019Context db, int productID)
        {


            AdventureWorksAPI.Models.Product? findedProduct = db.Products.Find(productID);

            if (findedProduct == null)
            {
                return Results.NotFound(productID);
            }
            db.Products.RemoveRange(findedProduct);
            db.SaveChangesAsync();

            return Results.Ok();

        }
        public static IResult GetProductDetail(AdventureWorksLt2019Context db, int productID)
        {

             var result =   (from a in db.Products
                            join b in db.ProductCategories
                            on a.ProductCategoryId equals b.ProductCategoryId
                            join c in db.ProductModels
                            on a.ProductModelId equals c.ProductModelId
                            where a.ProductId== productID
                            select new {product=a,cate=b,model=c }).FirstOrDefault(); 

            if (result == null)
            {
                return Results.NotFound(productID);
            }

            var resultDescriptions = db.VProductAndDescriptions.Where(c => c.ProductId == productID).ToList();
                                    

            foreach(var item in resultDescriptions)
            {
                ProductDescription pd = new ProductDescription();
                pd.Description=item.Description; 
                result.product.ProductDescriptions.Add(pd);
            }

            

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MaxDepth = 2;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.ContractResolver = new DefaultContractResolver();

            var json =JsonConvert.SerializeObject(result.product, settings);
            
            JObject jObj = JObject.Parse(json);

            Models.Product product = JsonConvert.DeserializeObject<Models.Product>(jObj.ToString());

            return Results.Ok(new {product=product });

        }
    }

}
