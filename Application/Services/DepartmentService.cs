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

        public async Task<OperationResult<Department>> CreateAsync(Department department)
        {
            try
            {
                var result = await _departmentRepository.CreateAsync(department);
                if (!result.Success)
                    return OperationResult<Department>.CreateFail("There was an unexpected error, please try again");

                return OperationResult<Department>.CreateSuccess(department);
            }
            catch
            {
                return OperationResult<Department>.CreateFail("There was an unexpected error, please try again");
            }
        }

        public async Task<OperationResult> DeleteAsync(int id)
        {
            try
            {
                if (id == 0)
                    return OperationResult.CreateFail("Id not found.");

                var result = await _departmentRepository.DeleteAsync(id);
                if (!result.Success)
                    return OperationResult.CreateFail("There was an unexpected error, please try again");

                return OperationResult.CreateSuccess();
            }
            catch 
            {
                return OperationResult.CreateFail("There was an unexpected error, please try again");
            }
            
        }

        public async Task<OperationResult<Department>> EditAsync(Department department)
        {
            try
            {
                var result = await _departmentRepository.EditAsync(department);
                if (result == null)
                    return OperationResult<Department>.CreateFail("Department not found.");

                return OperationResult<Department>.CreateSuccess(department);
            }
            catch
            {
                return OperationResult<Department>.CreateFail("There was an unexpected error, please try again");
            }
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _departmentRepository.FindAllAsync();
        }

        public async Task<OperationResult<Department>> GetByIdAsync(int id)
        {
            try
            {
                if (id == 0)
                    return OperationResult<Department>.CreateFail("Id not found");

                var result = await _departmentRepository.GetByIdAsync(id);
                if (result == null)
                    return OperationResult<Department>.CreateFail("Department not found.");

                return OperationResult<Department>.CreateSuccess(result);
            }
            catch 
            {
                return OperationResult<Department>.CreateFail("There was an unexpected error, please try again");
            }
        }
    }
}
