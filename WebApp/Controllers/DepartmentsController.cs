using System.Data;
using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DepartmentsController : Controller
    {

        //Like in Router.js this index name indicate the display element interface referente to his
        //father, so if you use Index referente to root "/" you don't need pass any more argument on url
        //just the name from the model of this controller ViewData["Title"] = "Departments";


        public async Task<IActionResult> Index()
        {
            using var dp = new DepartmentContext();
            return View(await dp.Department.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            using var dp = new DepartmentContext();
            var department = await dp.Department
             .FirstOrDefaultAsync(d => d.Id == id);
            if (department == null) return NotFound();
            ViewData["Name"] = department?.Name;
            return View(department);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                using var dp = new DepartmentContext();
                await dp.Database.EnsureCreatedAsync();
                int id = dp.Department.Count() + 1;
                department.Id = id;
                await dp.Department.AddAsync(department);
                await dp.SaveChangesAsync();
            }
            return View(department);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            using var dp = new DepartmentContext();
            if (dp == null) return NotFound();
            var department = await dp.Department.FindAsync(id);

            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id, Name")] Department department)
        {
            if (department.Id != id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    using var dp = new DepartmentContext();
                    dp.Update(department);
                    await dp.SaveChangesAsync();
                }
                catch (DBConcurrencyException)
                {
                    if (!DepartmentExists(department.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            using var dp = new DepartmentContext();
            var department = await dp.Department.FirstOrDefaultAsync(d => d.Id == id);
            if (department == null) return NotFound();
            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var dp = new DepartmentContext();
            var department = await dp.Department.FindAsync(id);
            if (department == null) return NotFound();
            dp.Remove(department);
            await dp.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private static bool DepartmentExists(int id)
        {
            using var dp = new DepartmentContext();
            return dp.Department.Any(e => e.Id == id);
        }


    }

}