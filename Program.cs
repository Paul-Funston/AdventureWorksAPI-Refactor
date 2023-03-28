
using AdventureWorksAPI.AddressMethods;
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

// Product

// SalesOrderHeader
app.MapGet("/address", MethodForAddress.GetAddress);
app.MapPost("/address", MethodForAddress.Create);
app.Run();