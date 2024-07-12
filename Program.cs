using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductWarehouseAuth.Api.Dtos;
using ProductWarehouseAuth.Core.Entity;
using ProductWarehouseAuth.Data;
using ProductWarehouseAuth.Data.IRepo;
using ProductWarehouseAuth.Service;
using ProductWarehouseAuth.Service.IServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(UserService), typeof(UserService));
builder.Services.AddScoped(typeof(ProductService), typeof(ProductService));
builder.Services.AddScoped(typeof(WarehouseService), typeof(WarehouseService));
builder.Services.AddScoped(typeof(StockService), typeof(StockService)); 
builder.Services.AddTransient<IService, AuthService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    options.UseNpgsql(builder.Configuration.GetConnectionString("postgresconnectionstring"));
//});

// for authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//AppDbContext db = new AppDbContext();

//app.MapGet("/", () =>
//{
//    //return db.warehouse.ToList();
//});
//app.MapGet("/warehouse", (WarehouseService warehouseService) =>
//{
//    return warehouseService.GetAllWarehouse();
//});

//app.MapGet("")
//app.MapPost("AddUser", (UserDto userdto, UserService userService) =>
//{
//    var user = new User()
//    {
//        name = userdto.Name,
//        email = userdto.Email,
//        password = userdto.Password
//    };
//    userService.RegisterUser(user);
//    return user;
//});

app.MapGet("AllUser", (UserService userService) =>
{
    return userService.GetAll();
});

app.Run();
