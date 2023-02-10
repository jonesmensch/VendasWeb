﻿using Domain.Interfaces.Application.Services;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            var findAll = _sellerService.FindAll();
            return View(findAll);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var sellerForm = new SellerFormViewModel { Departments = departments };
            return View(sellerForm);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
                return NotFound();

            var obj = _sellerService.GetById(id);
            if (obj == null)
                return NotFound();

            var departments = _departmentService.FindAll();
            var sellerForm = new SellerFormViewModel { Departments = departments , Seller = obj };

            return View(sellerForm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Create(seller);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if ()
            _sellerService.Edit(seller);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _sellerService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}