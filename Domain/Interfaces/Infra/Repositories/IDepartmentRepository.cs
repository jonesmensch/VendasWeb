using Domain.Models;

namespace Domain.Interfaces.Infra.Repositories
{
    public interface IDepartmentRepository
    {
        public List<Department> FindAll();
        public Department GetById(int id);
        public Department Create(Department department);
        public Department Edit(Department department);
        public bool Delete(int id);
    }
}
