using AdventureWorksAPI.CustomerMethod;
using AdventureWorksAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AdventureWorksLt2019Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AdventureWorksDb")));

var app = builder.Build();

/*----- END POINTS ----- */

// Address

// Customer
// READ
app.MapGet("/customers", CustomerMethods.GetCustomers);
app.MapGet("/customer", CustomerMethods.GetCustomer);

//CREATE
app.MapPost("/customer/create", CustomerMethods.AddCustomer);



// Product

// SalesOrderHeader


app.Run();