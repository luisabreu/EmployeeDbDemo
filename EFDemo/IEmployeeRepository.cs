namespace EFDemo {
    public interface IEmployeeRepository {
        void Save(Employee employee);
        Employee Load(int employeeId);
    }
}