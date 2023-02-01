using Domain.Interfaces.Application.Services;
using Domain.Interfaces.Infra.Repositories;
using Domain.Models;

namespace Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public Department Create(Department department)
        {
            return _departmentRepository.Create(department);
        }

        public bool Delete(int id)
        {
            return _departmentRepository.Delete(id);
        }

        public List<Department> FindAll()
        {
            return _departmentRepository.FindAll();
        }
    }
}
