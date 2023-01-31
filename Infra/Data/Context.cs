using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasWeb.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Department> departments { get; set; }
    }
}