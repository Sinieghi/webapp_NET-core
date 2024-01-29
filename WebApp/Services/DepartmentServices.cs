
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Services
{
    public class DepartmentServices
    {
        private readonly WebAppContext _context = new();

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(d => d.Name).ToListAsync();
        }

    }
}