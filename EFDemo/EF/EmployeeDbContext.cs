using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EFDemo.EF {
    public class EmployeeDbContext : DbContext {
        public EmployeeDbContext(string nameOrConnectionString) 
            : base(nameOrConnectionString) {
        }

        //public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.AddFromAssembly(typeof (Employee).Assembly);
        }
    }
}