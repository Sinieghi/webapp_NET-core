using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class SellersController(SellerServices sellerServices) : Controller
    {

        private readonly SellerServices _sellerServices = sellerServices;

        public IActionResult Index()
        {
            var sellers = _sellerServices.FindAll();
            return View(sellers);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerServices.Insert(seller);

            return RedirectToAction(nameof(Index));
        }

    }

}