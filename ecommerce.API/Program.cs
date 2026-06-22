using eCommaerce.Core;
using eCommaerce.Core.IRepo;
using eCommaerce.Core.IServices;
using eCommaerce.Core.Services;
using ecommerce.API.Middleware;
using eCommerce.Infra;
using eCommerce.Infra.AppDbContext;
using eCommerce.Infra.Repo;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfra();
builder.Services.AddCore();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Dbcs")));
builder.Services.AddScoped<IUserRepository, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddControllers().AddJsonOptions(option => option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();
app.UseExeptionMiddleware();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
