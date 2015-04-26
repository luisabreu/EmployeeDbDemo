namespace EFDemo {
    public class EmployeeType {
        public int EmployeeTypeId { get; private set; }
        public string Designation { get; private set; }

        public EmployeeType(string designation, int employeeTypeId) {
            Designation = designation;
            EmployeeTypeId = employeeTypeId;
        }

        private EmployeeType() : this("", 0) {
        }

        public override string ToString() {
            return string.Format("{0} ({1})", Designation, EmployeeTypeId);
        }
    }
}