using Domain.Interfaces.Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

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
            var findAll = _departmentsService.FindAll();
            return View(findAll);
        }

        public IActionResult Delete(int id)
        {
            _departmentsService.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            _departmentsService.Create(department);

            return RedirectToAction("Index");
        }
    }
}
