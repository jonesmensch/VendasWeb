using Domain.Models;

namespace Domain.Interfaces.Application.Services
{
    public interface IDepartmentService
    {
        public List<Department> FindAll();
        public OperationResult<Department> Create(Department department);
        public OperationResult<Department> Edit(Department department);
        public OperationResult Delete(int id);
        public OperationResult<Department> GetById(int id);
    }
}
