using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace EFDemo.NH {
    public class EmployeeMappings : ClassMap<Employee> {
        public EmployeeMappings() {
            Table("Employees");
            Not.LazyLoad();

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
                        .CustomSqlType("integer")
                        .CustomType<ContactKind>()
                        .Not.Nullable();
                })
                .Table("Contacts")
                .Not.LazyLoad();
            References<EmployeeType>(Reveal.Member<Employee>("_employeeType"))
                .Column("EmployeeTypeId")
                .Not.Nullable()
                .Cascade.None();
        }
    }
}