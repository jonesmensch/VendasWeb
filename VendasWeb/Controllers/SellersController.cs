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

        public async Task<IActionResult> Index()
        {
            return View(await _sellerService.FindAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var sellerForm = new SellerFormViewModel { Departments = departments };
            return View(sellerForm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _sellerService.GetByIdAsync(id);
            if (result.Success)
                return View(result.Model);

            return View("Error", new ErrorViewModel(result.Message));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            if (ModelState.IsValid)
            {
                var result = await _sellerService.CreateAsync(seller);
                if (result.Success)
                    return RedirectToAction("Index");

                return View("Error", new ErrorViewModel(result.Message));
            }
            return View("Create", seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (ModelState.IsValid)
            {
                var result = await _sellerService.EditAsync(seller);
                if (result.Success)
                    return RedirectToAction("Index");

                return View("Error", new ErrorViewModel(result.Message));
            }
            return View("Edit", seller);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _sellerService.DeleteAsync(id);
            if (result.Success)
                return RedirectToAction("Index");

            return View("Error", new ErrorViewModel(result.Message));
        }
    }
}
