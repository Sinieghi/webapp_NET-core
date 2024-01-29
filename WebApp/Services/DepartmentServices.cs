
using WebApp.Models;

namespace WebApp.Services
{
    public class DepartmentServices
    {
        private readonly WebAppContext _context = new();

        public List<Department> FindAll()
        {
            return [.. _context.Department.OrderBy(d => d.Name)];
        }

    }
}