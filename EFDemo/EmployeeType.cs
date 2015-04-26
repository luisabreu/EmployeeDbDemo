namespace EFDemo {
    public class EmployeeType {
<<<<<<< HEAD
        public int EmployeeTypeId { get; private set; }
        public string Designation { get; private set; }
=======
        public int EmployeeTypeId { get; set; }
        public string Designation { get; set; }
>>>>>>> e96e826d0fb5be89e7f6b512fd6afe010b3a8630

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