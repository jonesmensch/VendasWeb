using Domain;
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

        public OperationResult<Department> Create(Department department)
        {
            return _departmentRepository.Create(department);
        }

        public OperationResult Delete(int id)
        {
            return _departmentRepository.Delete(id);
        }

        public OperationResult<Department> Edit(Department department)
        {
            return _departmentRepository.Edit(department);
        }

        public List<Department> FindAll()
        {
            return _departmentRepository.FindAll();
        }
    }
}
