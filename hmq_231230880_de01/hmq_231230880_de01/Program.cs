using hmq_231230880_de01.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HoangManhQuan231230880De01Context>(options =>
    options.UseSqlServer(connnectionString));
// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HmqHome}/{action=Index}/{id?}");

app.Run();
