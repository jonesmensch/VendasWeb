using Domain.Models;

namespace Domain.Interfaces.Application.Services
{
    public interface IDepartmentService
    {
        public List<Department> FindAll();
        public Department Create(Department department);
        public Department Edit(Department department);
        public bool Delete(int id);
    }
}
