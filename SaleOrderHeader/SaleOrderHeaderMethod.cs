using AdventureWorksAPI.Models;
using Microsoft.CodeAnalysis;

namespace AdventureWorksAPI.SaleOrderHeader
{
    public static class SaleOrderHeaderMethod
    {

        public static IResult GetOrder(AdventureWorksLt2019Context db, int? orderID)
        {
            if (orderID == null)
            {
                return Results.Ok(db.SalesOrderHeaders.ToList());
            }

            var order = db.SalesOrderHeaders.Where(p => p.SalesOrderId == orderID).FirstOrDefault();
            if (order == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(order);
        }
        public static IResult AddOrder(AdventureWorksLt2019Context db, AdventureWorksAPI.Models.SalesOrderHeader order)
        {
            //test json : {"RevisionNumber":2,"ShipMethod":"ddd","CustomerId"=30113}
            order.OrderDate= DateTime.Now;
            order.DueDate= DateTime.Now;
            order.Status = 5;                
            order.Rowguid = System.Guid.NewGuid();
            order.ModifiedDate = System.DateTime.Now;
            db.SalesOrderHeaders.Add(order);
            db.SaveChanges();

            return Results.Ok();
             
        }
        public static IResult UpdateOrder(AdventureWorksLt2019Context db, AdventureWorksAPI.Models.SalesOrderHeader order)
        {
            //test json: {"SalesOrderID":71947,"ShipMethod":"test"}"

            AdventureWorksAPI.Models.SalesOrderHeader? findedOrder = db.SalesOrderHeaders.Find(order.SalesOrderId);

            if (findedOrder == null)
            {
                return Results.NotFound(order.SalesOrderId);
            }

            findedOrder.ShipMethod = order.ShipMethod;
            db.SaveChanges();

            return Results.Ok();

        }
        public static IResult DeleteOrder(AdventureWorksLt2019Context db, int orderID)
        {

            AdventureWorksAPI.Models.SalesOrderHeader? findedOrder = db.SalesOrderHeaders.Find(orderID);

            if (findedOrder == null)
            {
                return Results.NotFound(orderID);
            }
            db.SalesOrderHeaders.RemoveRange(findedOrder);
            db.SaveChanges();;

            return Results.Ok();

        }
    }

}
