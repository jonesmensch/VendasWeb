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

        public bool Delete(int id)
        {
            Department department = GetById(id);

            _context.Remove(department);
            _context.SaveChanges();

            return true;
        }

        public Department Create(Department department)
        {
            _context.Add(department);
            _context.SaveChanges();

            return department;
        }

        public Department Edit(Department department)
        {
            var edit = GetById(department.Id);

            if(edit == null)
                throw new System.Exception("There was an error while trying to update!");

            edit.Name = department.Name;

            _context.departments.Update(edit);
            _context.SaveChanges();

            return edit;
        }

    }
}
