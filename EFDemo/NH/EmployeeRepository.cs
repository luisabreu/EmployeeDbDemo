using NHibernate;

namespace EFDemo.NH {
    public class EmployeeRepository : IEmployeeRepository {
        private readonly ISession _session;

        public EmployeeRepository(ISession session) {
            _session = session;
        }

        public void Save(Employee employee) {
            _session.SaveOrUpdate(employee);
        }

        public Employee Load(int employeeId) {
            return _session.Load<Employee>(employeeId);
        }
    }
}