using AdventureWorksAPI.CustomerMethod;
using AdventureWorksAPI.AddressMethods;
using AdventureWorksAPI.Models;
using AdventureWorksAPI.Product;
using AdventureWorksAPI.SaleOrderHeader;
using Lab3.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// SERVICES
builder.Services.AddDbContext<AdventureWorksLt2019Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AdventureWorksDb"));
});
var app = builder.Build();

/*----- END POINTS ----- */

// Address
app.MapGet("/address", MethodForAddress.GetAddress);
app.MapPost("/address", MethodForAddress.Create);
app.MapDelete("/address/delete", MethodForAddress.Delete);
app.MapPut("/address/update", MethodForAddress.Update);

// Customer
app.MapGet("/customers/{id}", CustomerMethods.GetCustomers);
app.MapPost("/customers/create", CustomerMethods.AddCustomer);

// Product
app.MapGet("/product", ProductMethod.GetProduct);

app.MapPost("/product", ProductMethod.AddProduct);

app.MapPut("/product", ProductMethod.UpdateProduct);

app.MapDelete("/product", ProductMethod.DeleteProduct);



// SalesOrderHeader
app.MapGet("/saleorderheader", SaleOrderHeaderMethod.GetOrder);

app.MapPost("/saleorderheader", SaleOrderHeaderMethod.AddOrder);

app.MapPut("/saleorderheader", SaleOrderHeaderMethod.UpdateOrder);

app.MapDelete("/saleorderheader", SaleOrderHeaderMethod.DeleteOrder);



app.Run();