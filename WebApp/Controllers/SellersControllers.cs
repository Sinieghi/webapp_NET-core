using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.ViewModels;
using WebApp.Services;
using WebApp.Services.Exceptions;

namespace WebApp.Controllers
{
    public class SellersController(SellerServices sellerServices, DepartmentServices departmentServices) : Controller
    {

        private readonly SellerServices _sellerServices = sellerServices;
        private readonly DepartmentServices _departmentServices = departmentServices;

        public async Task<IActionResult> Index()
        {
            var sellers = await _sellerServices.FindAllAsync();
            return View(sellers);
        }

        public async Task<IActionResult> Create()
        {

            var departments = await _departmentServices.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {

            if (!ModelState.IsValid)
            {

                var department = await _departmentServices.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = department };

                return View(viewModel);
            }

            await _sellerServices.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { msg = "Id not found" });
            //when declared as optional value int? id you have to pass the id."Value" to check if exist before proceed.
            var obj = await _sellerServices.FindByIdAsync(id.Value);

            if (obj == null) return RedirectToAction(nameof(Error), new { msg = "No such object with given id" });

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                await _sellerServices.RemoveAsync(id);
                return RedirectToAction(nameof(Index));

            }
            catch (IntegrityException E)
            {

                return RedirectToAction(nameof(Error), new { msg = E.Message });
            }

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { msg = "Id not found" });

            var obj = await _sellerServices.FindByIdAsync(id.Value);
            if (obj == null) return RedirectToAction(nameof(Error), new { msg = "No such object with given id" });
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null) return RedirectToAction(nameof(Error), new { msg = "Id not found" });

            var obj = await _sellerServices.FindByIdAsync(id.Value);

            if (obj == null) return RedirectToAction(nameof(Error), new { msg = "No such object with given id" });

            List<Department> departments = await _departmentServices.FindAllAsync();
            //this is a populate on input
            SellerFormViewModel sellerFormViewModel = new() { Seller = obj, Departments = departments };

            return View(sellerFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (id != seller.Id) return RedirectToAction(nameof(Error), new { msg = "The id does not match for some reason, check the url." });

            if (!ModelState.IsValid)
            {
                var department = await _departmentServices.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = department };
                return View(viewModel);
            }
            try
            {
                await _sellerServices.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { msg = e.Message });
            }
        }

        public IActionResult Error(string msg)
        {
            //request id 
            var viewModel = new ErrorViewModel { Message = msg, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };

            return View(viewModel);

        }

    }

}