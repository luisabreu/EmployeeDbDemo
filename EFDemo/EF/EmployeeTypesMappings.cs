using System.Data.Entity.ModelConfiguration;

namespace EFDemo.EF {
    public class EmployeeTypesMappings : EntityTypeConfiguration<EmployeeType> {
        public EmployeeTypesMappings() {
            ToTable("EmployeeTypes")
                .HasKey(e => e.EmployeeTypeId);

//            modelBuilder.Entity<EmployeeType>()
//                .Property(e => e.EmployeeTypeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
//                .HasColumnName("EmployeeTypeId");
        }
    }
}