using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq.Expressions;
using FluentNHibernate;
using NHibernate.Criterion;
using NHibernate.Engine;

namespace EFDemo.EF {
    public class EfDemoContext : DbContext {
        public EfDemoContext(string cnnString): base(cnnString){
        }

        //  public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            MapEmployeeType(modelBuilder);
            MapEmployee(modelBuilder);
        }

        private void MapEmployee(DbModelBuilder modelBuilder) {
            var entityBuilder = modelBuilder.Entity<Employee>();
            entityBuilder.HasKey(Reveal.Member<Employee>("_empoyeeId")).ToTable("Employees");
            

            
        //    entityBuilder.Property(Reveal.Member<Employee>("_employeeId")).HasColumnName("EmployeeId");


        }

        private void MapEmployeeType(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<EmployeeType>()
                .ToTable("EmployeeTypes")
                .HasKey(et =>et.EmployeeTypeId)
                .Property(et => et.Designation);
        }

    }
}