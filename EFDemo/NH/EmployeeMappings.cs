using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace EFDemo.NH {
    public class EmployeeMappings : ClassMap<Employee> {
        public EmployeeMappings() {
            Table("Employees");
            Not.LazyLoad();

            Id(Reveal.Member<Employee>("EmployeeId"))
                .GeneratedBy.Identity();
            Version(Reveal.Member<Employee>("Version"))
                .CustomSqlType("rowversion")
                .CustomType<byte[]>()
                .Generated.Always();
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
                        .CustomSqlType("integer")
                        .CustomType<ContactKind>()
                        .Not.Nullable();
                })
                .Table("Contacts")
                .Not.LazyLoad();
            References<EmployeeType>(Reveal.Member<Employee>("EmployeeType"))
                .Column("EmployeeTypeId")
                .Not.Nullable()
                .Cascade.None();
        }
    }
}