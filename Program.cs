using AdventureWorksAPI.CustomerMethod;
using AdventureWorksAPI.AddressMethods;
using AdventureWorksAPI.Models;
using AdventureWorksAPI.Product;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AdventureWorksLt2019Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AdventureWorksDb")));

var app = builder.Build();

/*----- END POINTS ----- */

// Address
app.MapGet("/address", MethodForAddress.GetAddress);
app.MapPost("/address", MethodForAddress.Create);

// Customer
app.MapGet("/customers/{id?}", CustomerMethods.GetCustomers);
app.MapPost("/customers/create", CustomerMethods.AddCustomer);
app.MapPut("/customers/update/{id}", CustomerMethods.UpdateCustomer);

// Product
app.MapGet("/product", ProductMethod.GetProduct);
 
// SalesOrderHeader


app.Run();