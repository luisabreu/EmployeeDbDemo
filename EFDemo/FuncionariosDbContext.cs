using System.Data.Entity;
using System.Reflection;

namespace EFDemo {
   /* public class FuncionariosDbContext : DbContext {
        public DbSet<Employee> Funcionarios { get; set; }
        public DbSet<EmployeeType> TiposFuncionario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.
                .Configure(c => {
                    var nonPublicProperties = c.ClrType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);

                    foreach (var p in nonPublicProperties) {
                        c.Property(p).HasColumnName(p.Name);
                    }
                });
        }
    }*/
}