using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cw10.Data;
using Cw10.Models;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<Cw10Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Cw10Context") ?? throw new InvalidOperationException("Connection string 'Cw10Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
