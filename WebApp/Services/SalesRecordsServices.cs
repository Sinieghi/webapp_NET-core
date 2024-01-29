
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Services
{
    public class SalesRecordsServices
    {
        private readonly WebAppContext _context = new();

        public async Task<List<SalesRecords>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var res = from obj in _context.SalesRecords select obj;
            if (minDate.HasValue)
            {
                res = res.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                res = res.Where(x => x.Date <= maxDate.Value);
            }

            return await res
            .Include(inc => inc.Seller)
            .Include(inc => inc.Seller.Department)
            .OrderByDescending(y => y.Date)
            .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecords>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var res = from obj in _context.SalesRecords select obj;
            if (minDate.HasValue)
            {
                res = res.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                res = res.Where(x => x.Date <= maxDate.Value);
            }

            return await res
            .Include(inc => inc.Seller)
            .Include(inc => inc.Seller.Department)
            .OrderByDescending(y => y.Date)
            .GroupBy(x => x.Seller.Department)
            .ToListAsync();
        }

    }
}