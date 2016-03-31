using System.Linq;

namespace EFDemo.EF {
    public class EmployeeRepository : IEmployeeRepository {
        private readonly EfDemoContext _context;

        public EmployeeRepository(EfDemoContext context) {
            _context = context;
        }

        public void Save(Employee employee) {
            _context.Employees.Add(employee);
        }

        public Employee Load(int employeeId) {
            return _context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
        }
    }
}