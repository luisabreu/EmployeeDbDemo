using FluentNHibernate.Mapping;

namespace EFDemo.NH {
    public class EmployeeTypeMappings : ClassMap<EmployeeType> {
        public EmployeeTypeMappings() {
            Table("EmployeeTypes");
            Not.LazyLoad();

            Id(e => e.EmployeeTypeId)
                .GeneratedBy.Identity();
            Map(e => e.Designation);
        }
    }
}