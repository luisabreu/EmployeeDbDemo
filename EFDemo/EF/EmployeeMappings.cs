using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFDemo {
    public partial class Employee {
        public class EmployeeMappings : EntityTypeConfiguration<Employee> {
            public EmployeeMappings() {
                ToTable("Employees").HasKey(e => e.EmployeeId);
                Property(e => e.Name).IsRequired();
                Property(e => e.Address).IsRequired();
                
                Property(e => e.Version).IsConcurrencyToken()
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            }
        }
    }
}