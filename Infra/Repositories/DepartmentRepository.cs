using Domain.Interfaces.Infra.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return _context.departments.ToList();
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

    }
}
