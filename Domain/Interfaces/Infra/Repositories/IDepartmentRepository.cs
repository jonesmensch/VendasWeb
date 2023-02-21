using Domain.Models;

namespace Domain.Interfaces.Infra.Repositories
{
    public interface IDepartmentRepository
    {
        public Task<List<Department>> FindAllAsync();
        public Task<Department> GetByIdAsync(int id);
        public Task<OperationResult<Department>> CreateAsync(Department department);
        public Task<OperationResult<Department>> EditAsync(Department department);
        public Task<OperationResult> DeleteAsync(int id);
    }
}
