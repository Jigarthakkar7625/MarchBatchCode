using Microsoft.EntityFrameworkCore;

namespace MyFirstCoreWebSite.Models
{
    public class TestDBMAJwtMigrationContext : DbContext
    {
        public TestDBMAJwtMigrationContext()
        {
        }

        public TestDBMAJwtMigrationContext(DbContextOptions<TestDBMAJwtMigrationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
