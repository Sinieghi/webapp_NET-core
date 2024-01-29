using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class SalesRecordsController(SalesRecordsServices salesRecordsServices) : Controller
    {

        private readonly SalesRecordsServices _salesRecordsServices = salesRecordsServices;
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue) minDate = new DateTime(DateTime.Now.Year, 1, 1);
            if (!maxDate.HasValue) maxDate = new DateTime(DateTime.Now.Year, 1, 1);
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var res = await _salesRecordsServices.FindByDateAsync(minDate, maxDate);
            return View(res);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue) minDate = new DateTime(DateTime.Now.Year, 1, 1);
            if (!maxDate.HasValue) maxDate = new DateTime(DateTime.Now.Year, 1, 1);
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var res = await _salesRecordsServices.FindByDateGroupingAsync(minDate, maxDate);
            return View(res);
        }
    }
}