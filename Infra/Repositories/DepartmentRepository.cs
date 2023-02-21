using Domain;
using Domain.Interfaces.Infra.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using VendasWeb.Data;

namespace Infra.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly Context _context;

        public DepartmentRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.departments.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _context.departments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<OperationResult> DeleteAsync(int id)
        {
            Department department = await GetByIdAsync(id);

            if (department == null)
                return OperationResult.CreateFail("Seller not found!");

            try 
            {
                _context.Remove(department);
                await _context.SaveChangesAsync();

                return OperationResult.CreateSuccess();
            }
            catch
            {
                return OperationResult.CreateFail("An error has occurred, please try again!");
            }
        }

        public async Task<OperationResult<Department>> CreateAsync(Department department)
        {
            try
            {
                await _context.AddAsync(department);
                await _context.SaveChangesAsync();

                return OperationResult<Department>.CreateSuccess(department);
            }
            catch
            {
                return OperationResult<Department>.CreateFail("An error has occurred, please try again.");
            }
        }

        public async Task<OperationResult<Department>> EditAsync(Department department)
        {
            try
            {
                var edit = await GetByIdAsync(department.Id);

                if (department.Id != edit.Id)
                    return OperationResult<Department>.CreateFail("Id mismatch");

                edit.Name = department.Name;

                _context.departments.Update(edit);
                await _context.SaveChangesAsync();

                return OperationResult<Department>.CreateSuccess(department);
            }
            catch
            {
                return OperationResult<Department>.CreateFail("There was an error while trying to update!");
            }
        }
    }
}
