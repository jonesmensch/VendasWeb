using Domain;
using Domain.Interfaces.Infra.Repositories;
using Domain.Models;
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

        public List<Department> FindAll()
        {
            return _context.departments.OrderBy(x => x.Name).ToList();
        }

        public Department GetById(int id)
        {
            return _context.departments.FirstOrDefault(x => x.Id == id);
        }

        public OperationResult Delete(int id)
        {
            try
            {
                Department department = GetById(id);

                if (department == null)
                    return OperationResult.CreateFail("An error has occurred, please try again!");

                _context.Remove(department);
                _context.SaveChanges();

                return OperationResult.CreateSuccess();
            }
            catch
            {
                return OperationResult.CreateFail("An error has occurred, please try again!");
            }
            
        }

        public OperationResult<Department> Create(Department department)
        {
            try
            {
                _context.Add(department);
                _context.SaveChanges();

                return OperationResult<Department>.CreateSuccess(department);
            }
            catch
            {
                return OperationResult<Department>.CreateFail(department, "There was an unexpected error, please try again!");
            }
        }

        public OperationResult<Department> Edit(Department department)
        {
            var edit = GetById(department.Id);

            try
            {
                if (edit == null)
                    throw new System.Exception("There was an error while trying to update!");

                edit.Name = department.Name;

                _context.departments.Update(edit);
                _context.SaveChanges();

                return OperationResult<Department>.CreateSuccess(department);
            }
            catch
            {
                return OperationResult<Department>.CreateFail(department, "There was an error while trying to update!");
            }
        }

    }
}
