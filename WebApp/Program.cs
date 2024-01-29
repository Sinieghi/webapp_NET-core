
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using WebApp;
using WebApp.Models;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<SellerServices>();
builder.Services.AddScoped<DepartmentServices>();
builder.Services.AddScoped<SalesRecordsServices>();

var app = builder.Build();
var enUS = new CultureInfo("en-US");
var localizationOpts = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = [enUS],
    SupportedUICultures = [enUS]
};
app.UseRequestLocalization(localizationOpts);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    var WebApp = new WebAppContext();
    new Populate(WebApp).Seed();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// using var departmentContext = new WebAppContext();
// departmentContext.Database.EnsureCreated();

// var department = new Department { Id = 7, Name = "Luiz" };
// var x = new Seller(10, "Cool", "x@y.z", new DateTime(1995, 01, 28), -2000, department);
// var s = new SalesRecords(0, new DateTime(1995, 01, 28), 10, SalesStatus.Billed, x);
// x.AddSales(s);
// department.AddSeller(x);

// departmentContext.Add(department);

// departmentContext.SaveChanges();
app.Run();
