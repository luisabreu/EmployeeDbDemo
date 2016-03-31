using Microsoft.Data.Entity;

namespace EFDemo.EF {
    public class EfDemoContext : DbContext {
        private readonly string _cnnString;

        public EfDemoContext(string cnnString) {
            _cnnString = cnnString;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(_cnnString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            MapEmployeeType(modelBuilder);
            MapEmployee(modelBuilder);
        }

        private void MapEmployee(ModelBuilder modelBuilder) {
            var entityBuilder = modelBuilder.Entity<Employee>();
            
            entityBuilder.ToTable("Employees");
            entityBuilder.HasKey(e => e.EmployeeId);
            entityBuilder.Property(e => e.Version)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            //    entityBuilder.Property(Reveal.Member<Employee>("_employeeId")).HasColumnName("EmployeeId");
        }

        private void MapEmployeeType(ModelBuilder modelBuilder) {
           var employeeTypesBuilder =  modelBuilder.Entity<EmployeeType>();
            employeeTypesBuilder.ToTable("EmployeeTypes");
            employeeTypesBuilder.HasKey(et => et.EmployeeTypeId);
        }
    }
}