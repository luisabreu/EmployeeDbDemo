using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace EFDemo.NH {
    public class EmployeeMappings : ClassMap<Employee> {
        public EmployeeMappings() {
            Table("Employees");
            Not.LazyLoad();

<<<<<<< HEAD
            Id(Reveal.Member<Employee>("EmployeeId"))
                .GeneratedBy.Identity();
            Version(Reveal.Member<Employee>("Version"));
            Map(Reveal.Member<Employee>("Name"));
            Map(Reveal.Member<Employee>("Address"));
            HasMany<Contact>(Reveal.Member<Employee>("Contacts"))
                .KeyColumn("EmployeeId")
                .Component(c => {
                    c.Map(Reveal.Member<Contact>("Value"))
                    .Column("Contact")
                        .Not.Nullable();
                    c.Map(Reveal.Member<Contact>("Kind"))
                    .Column("ContactKind")
=======
            Id(Reveal.Member<Employee>("_employeeId"))
                .Column("EmployeeId")
                .GeneratedBy.Identity();
            Version(Reveal.Member<Employee>("_version")).Column("Version");
            Map(Reveal.Member<Employee>("_name"))
                .Column("Name");
            Map(Reveal.Member<Employee>("_address"))
                .Column("Address");
            HasMany<Contact>(Reveal.Member<Employee>("_contacts"))
                .KeyColumn("EmployeeId")
                .Component(c => {
                    c.Map(Reveal.Member<Contact>("_contact"))
                        .Column("Contact")
                        .Not.Nullable();
                    c.Map(Reveal.Member<Contact>("_contactKind"))
                        .Column("ContactKind")
>>>>>>> e96e826d0fb5be89e7f6b512fd6afe010b3a8630
                        .CustomSqlType("integer")
                        .CustomType<ContactKind>()
                        .Not.Nullable();
                })
                .Table("Contacts")
                .Not.LazyLoad();
<<<<<<< HEAD
            References<EmployeeType>(Reveal.Member<Employee>("EmployeeType"))
=======
            References<EmployeeType>(Reveal.Member<Employee>("_employeeType"))
>>>>>>> e96e826d0fb5be89e7f6b512fd6afe010b3a8630
                .Column("EmployeeTypeId")
                .Not.Nullable()
                .Cascade.None();
        }
    }
}