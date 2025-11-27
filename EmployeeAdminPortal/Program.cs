using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Services.Implementations;
using EmployeeAdminPortal.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);//To load appsettings.json & loads configuration 

// Add services to the container.
builder.Services.AddControllers();//to add controllers

// Add Swagger (OpenAPI)
builder.Services.AddEndpointsApiExplorer();//adds API Documentation
builder.Services.AddSwaggerGen();

// Configure Database Connection
builder.Services.AddDbContext<ApplicationDbContext>(options => //tells asp.net core it want to use ef and sql db
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")) // reads value from appsettings.json
);

// Service registration 
builder.Services.AddScoped<IEmployeeService, EmployeeService>(); // register employeeservice


var app = builder.Build();//Building the app

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())//while development use swagger
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();//enabling https

app.UseAuthorization();

app.MapControllers();//activates controllers

app.Run();//running app
