using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Application.Services
{
    public interface IDepartmentService
    {
        public List<Department> FindAll();
        public Department Create(Department department);
        public Department Update(Department department);
        public bool Delete(int id);
    }
}
