using eCommerce.Infra;
using eCommaerce.Core;
using ecommerce.API.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfra();
builder.Services.AddCore(); 

builder.Services.AddControllers();

var app = builder.Build();
app.UseExeptionMiddleware()
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
