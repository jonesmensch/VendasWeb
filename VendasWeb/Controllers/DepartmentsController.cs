using Domain.Interfaces.Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            return View(await _departmentsService.FindAllAsync());
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _departmentsService.DeleteAsync(id);
            if (result.Success)
                return RedirectToAction("Index");

            return View("Error", new ErrorViewModel(result.Message));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _departmentsService.GetByIdAsync(id);
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
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {

                var result = await _departmentsService.CreateAsync(department);
                if (result.Success)
                    return RedirectToAction("Index");

                return View("Error", new ErrorViewModel(result.Message));
            }
            return View("Create", department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Department department, int? id)
        {
            if (ModelState.IsValid)
            {
                if (id != department.Id)
                    throw new System.Exception("Id mismath");

                await _departmentsService.EditAsync(department);

                return RedirectToAction("Index");
            }
            return View("Edit", department);
        }
    }
}
