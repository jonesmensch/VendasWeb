using Domain.Interfaces.Application.Services;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using VendasWeb.Models;

namespace VendasWeb.Controllers
{
    public class SellersController : Controller
    {
        private readonly ISellerService _sellerService;
        private readonly IDepartmentService _departmentService;

        public SellersController(ISellerService sellerService, IDepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            return View(_sellerService.FindAll());
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var sellerForm = new SellerFormViewModel { Departments = departments };
            return View(sellerForm);
        }

        public IActionResult Edit(int id)
        {
            var result = _sellerService.GetById(id);
            if (result.Success)
                return View(result.Model);

            return View("Error", new ErrorViewModel(result.Message));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            if (ModelState.IsValid)
            {
                var result = _sellerService.Create(seller);
                if (result.Success)
                    return RedirectToAction("Index");

                return View("Error", new ErrorViewModel(result.Message));
            }
            return View("Create", seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (ModelState.IsValid)
            {
                var result = _sellerService.Edit(seller);
                if (result.Success)
                    return RedirectToAction("Index");

                return View("Error", new ErrorViewModel(result.Message));
            }
            return View("Edit", seller);
        }

        public IActionResult Delete(int id)
        {
            var result = _sellerService.Delete(id);
            if (result.Success)
                return RedirectToAction("Index");

            return View("Error", new ErrorViewModel(result.Message));
        }
    }
}
