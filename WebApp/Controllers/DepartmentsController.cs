using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DepartmentsController : Controller
    {

        public async Task<IActionResult> Index()
        {
            using var db = new WebAppContext();
            return View(await db.Department.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            using var db = new WebAppContext();
            var department = await db.Department
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
                using var db = new WebAppContext();
                await db.Database.EnsureCreatedAsync();
                int id = db.Department.Count() + 1;
                department.Id = id;
                await db.Department.AddAsync(department);
                await db.SaveChangesAsync();
            }
            return View(department);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            using var db = new WebAppContext();
            if (db == null) return NotFound();
            var department = await db.Department.FindAsync(id);

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
                    using var db = new WebAppContext();
                    db.Update(department);
                    await db.SaveChangesAsync();
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
            using var db = new WebAppContext();
            var department = await db.Department.FirstOrDefaultAsync(d => d.Id == id);
            if (department == null) return NotFound();
            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var db = new WebAppContext();
            var department = await db.Department.FindAsync(id);
            if (department == null) return NotFound();
            db.Remove(department);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private static bool DepartmentExists(int id)
        {
            using var db = new WebAppContext();
            return db.Department.Any(e => e.Id == id);
        }


    }

}