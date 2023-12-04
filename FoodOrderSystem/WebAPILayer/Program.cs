

using Microsoft.EntityFrameworkCore;
using Repository_And_Services.Context;
using Repository_And_Services.Repository;
using Repository_And_Services.Services.Custom.CustomerServices;
using Repository_And_Services.Services.Custom.FoodServices;
using Repository_And_Services.Services.Custom.OrderServices;
using Repository_And_Services.Services.Custom.SupplierServices;
using Repository_And_Services.Services.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MainDBContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));
builder.Services.AddTransient(typeof(ICustomerService), typeof(CustomerService));
builder.Services.AddTransient(typeof(IFoodService), typeof(FoodService));
builder.Services.AddTransient(typeof(IOrderService), typeof(OrderService));
builder.Services.AddTransient(typeof(ISupplierService), typeof(SupplierService));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
