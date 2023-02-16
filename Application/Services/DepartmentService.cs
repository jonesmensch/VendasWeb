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
            try
            {
                var result = _departmentRepository.Create(department);
                if (!result.Success)
                    return OperationResult<Department>.CreateFail(result.Message);

                return OperationResult<Department>.CreateSuccess(department);
            }
            catch
            {
                return OperationResult<Department>.CreateFail("There was an unexpected error, please try again");
            }
        }

        public OperationResult Delete(int id)
        {
            try
            {
                if (id == 0)
                    return OperationResult.CreateFail("Id not found.");

                var result = _departmentRepository.Delete(id);
                if (!result.Success)
                    return OperationResult.CreateFail("There was an unexpected error, please try again");

                return OperationResult.CreateSuccess();
            }
            catch 
            {
                return OperationResult.CreateFail("There was an unexpected error, please try again");
            }
            
        }

        public OperationResult<Department> Edit(Department department)
        {
            try
            {
                var result = _departmentRepository.Edit(department);
                if (result == null)
                    return OperationResult<Department>.CreateFail("Department not found.");

                return OperationResult<Department>.CreateSuccess(department);
            }
            catch
            {
                return OperationResult<Department>.CreateFail("There was an unexpected error, please try again");
            }
        }

        public List<Department> FindAll()
        {
            return _departmentRepository.FindAll();
        }

        public OperationResult<Department> GetById(int id)
        {
            try
            {
                if (id == 0)
                    return OperationResult<Department>.CreateFail("Id not found");

                var result = _departmentRepository.GetById(id);
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
