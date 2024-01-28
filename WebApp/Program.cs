
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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

// using var departmentContext = new DepartmentContext();
// departmentContext.Database.EnsureCreated();
// var department = new Department { Id = 7, Name = "Luiz" };
// var department1 = new Department { Id = 8, Name = "É" };
// var department2 = new Department { Id = 9, Name = "Burro" };
// departmentContext.Add(department);
// departmentContext.Add(department1);
// departmentContext.Add(department2);

// departmentContext.SaveChanges();
app.Run();
