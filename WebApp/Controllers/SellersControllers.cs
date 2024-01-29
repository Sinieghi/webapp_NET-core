using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.ViewModels;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class SellersController(SellerServices sellerServices, DepartmentServices departmentServices) : Controller
    {

        private readonly SellerServices _sellerServices = sellerServices;
        private readonly DepartmentServices _departmentServices = departmentServices;
        public IActionResult Index()
        {
            var sellers = _sellerServices.FindAll();
            return View(sellers);
        }

        public IActionResult Create()
        {

            var departments = _departmentServices.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {

            _sellerServices.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            //when declared as optional value int? id you have to pass the id."Value" to check if exist before proceed.
            var obj = _sellerServices.FindById(id.Value);

            if (obj == null) return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            _sellerServices.Remove(id);
            return RedirectToAction(nameof(Index));


        }

        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var obj = _sellerServices.FindById(id.Value);
            if (obj == null) return NotFound();
            return View(obj);
        }

    }

}