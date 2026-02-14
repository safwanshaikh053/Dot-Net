using Microsoft.EntityFrameworkCore;

namespace DemoWebApp.Models
{
    public class EmpDbContext : DbContext
    {
        public DbSet<Emp> emps { get; set; }
        public EmpDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}