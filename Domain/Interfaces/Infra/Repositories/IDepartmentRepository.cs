using Domain.Models;

namespace Domain.Interfaces.Infra.Repositories
{
    public interface IDepartmentRepository
    {
        public List<Department> FindAll();
        public Department GetById(int id);
        public OperationResult<Department> Create(Department department);
        public OperationResult<Department> Edit(Department department);
        public OperationResult Delete(int id);
    }
}
