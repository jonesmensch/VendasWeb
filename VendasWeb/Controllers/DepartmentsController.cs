using Domain;
using Domain.Interfaces.Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VendasWeb.Models;

namespace VendasWeb.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _departmentsService;

        public DepartmentsController(IDepartmentService departmentsService)
        {
            _departmentsService = departmentsService;
        }

        public IActionResult Index()
        {
            return View(_departmentsService.FindAll());
        }

        public IActionResult Delete(int id)
        {
            var result = _departmentsService.Delete(id);
            if (result.Success)
                return RedirectToAction("Index");

            return View("Error", new ErrorViewModel(result.Message));
        }
        public IActionResult Edit(int id)
        {
            var result = _departmentsService.GetById(id);
            if (result.Success)
                return View(result.Model);

            return View("Error", new ErrorViewModel(result.Message));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            var result = _departmentsService.Create(department);
            if (result.Success)
                return RedirectToAction("Index");

            return View("Error", new ErrorViewModel(result.Message));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department, int? id)
        {
            if (id != department.Id)
                throw new System.Exception("Id mismath");

            _departmentsService.Edit(department);

            return RedirectToAction("Index");
        }
    }
}
