using AdventureWorksAPI.CustomerMethod;
using AdventureWorksAPI.AddressMethods;
using AdventureWorksAPI.Models;
using AdventureWorksAPI.Product;
using AdventureWorksAPI.SaleOrderHeader;
using Lab3.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using AdventureWorksAPI.Data;

var builder = WebApplication.CreateBuilder(args);
 
// SERVICES
builder.Services.AddDbContext<AdventureWorksLt2019Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AdventureWorksDb"));
});
builder.Services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IAddressRepo, AddressRepository>();
builder.Services.AddScoped<ICustomerAddressRepo, CustomerAddressRepo>();
var app = builder.Build();



/*----- END POINTS ----- */

// Address
app.MapGet("/address", MethodForAddress.GetAddress);
app.MapPost("/address", MethodForAddress.Create);
app.MapDelete("/address/delete/{id}", MethodForAddress.Delete);
app.MapPut("/address/update/{id}", MethodForAddress.Update);

//Methods
app.MapGet("/address/details", MethodForAddress.FindCustomerInAddress);

// Customer
app.MapGet("/customers/{id?}", CustomerMethods.GetCustomers);
app.MapPost("/customers/create", CustomerMethods.AddCustomer);
app.MapPut("/customers/update/{id}", CustomerMethods.UpdateCustomer);
app.MapPut("/customers/delete/{id}", CustomerMethods.DeleteCustomer);
app.MapPost("/customers/addToAddress/customer={CustomerId}&address={AddressId}", CustomerMethods.AddCustomerToAddress);
app.MapGet("/customers/details", CustomerMethods.FindAddressesInCustomer);



// Product
app.MapGet("/product", ProductMethod.GetProduct);

app.MapPost("/product", ProductMethod.AddProduct);

app.MapPut("/product", ProductMethod.UpdateProduct);

app.MapDelete("/product", ProductMethod.DeleteProduct);

app.MapGet("/product/details/{productID}", ProductMethod.GetProductDetail);  

// SalesOrderHeader
app.MapGet("/saleorderheader", SaleOrderHeaderMethod.GetOrder);

app.MapPost("/saleorderheader", SaleOrderHeaderMethod.AddOrder);

app.MapPut("/saleorderheader", SaleOrderHeaderMethod.UpdateOrder);

app.MapDelete("/saleorderheader", SaleOrderHeaderMethod.DeleteOrder);



app.Run();