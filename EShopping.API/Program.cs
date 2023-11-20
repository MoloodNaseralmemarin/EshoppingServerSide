using EShopping.Core.Repositories;
using EShopping.Infrastructure.Context;
using EShopping.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;


#region Add DbContext And DataBase
var configuration = new ConfigurationBuilder()
.SetBasePath(env.ContentRootPath)
.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
.Build();
builder.Services.AddDbContext<EShoppingDBContext>(options =>
{
    options.UseSqlServer(configuration.GetValue<string>("ConnectionStrings:EShoppingDB"));
});
#endregion
#region Application Services
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICalculationRepository,CalculationRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
#endregion



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region CORS
builder.Services.AddCors();
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

  

app.UseCors(config => config
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());


app.MapControllers();

app.Run();
