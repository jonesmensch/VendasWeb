using Domain.Models;

namespace Domain.Interfaces.Application.Services
{
    public interface IDepartmentService
    {
        public Task<List<Department>> FindAllAsync();
        public Task <OperationResult<Department>> CreateAsync(Department department);
        public Task<OperationResult<Department>> EditAsync(Department department);
        public Task<OperationResult> DeleteAsync(int id);
        public Task<OperationResult<Department>> GetByIdAsync(int id);
    }
}
