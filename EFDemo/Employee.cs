using System.Collections.Generic;
using System.Text;

namespace EFDemo {
<<<<<<< HEAD

    //NOTE: set as partial for simplifying EF mappings
    public partial class Employee {
        private IList<Contact> Contacts { get; set; } = new List<Contact>();
        public int EmployeeId { get; private set; }
        private string Address { get; set; }
        private string Name { get; set; }
        private EmployeeType EmployeeType { get; set; }
        private int Version { get; set; }

        //just for demo purposes...
        

        public void ChangeName(string name) {
            Name = name;
        }

        public void ChangeAdress(string address) {
            Address = address;
        }

        public void SetEmployeeType(EmployeeType employeeType) {
            EmployeeType = employeeType;
        }

        public void AddContact(Contact contact) {
            if (Contacts.Contains(contact)) {
                return;
            }
            Contacts.Add(contact);
        }

        public void RemoveContact(Contact contact) {
            Contacts.Remove(contact);
=======
    public class Employee {
        private IList<Contact> _contacts = new List<Contact>();
        private int _employeeId;
        private string _address;
        private string _name;
        private EmployeeType _employeeType;
        private int _version;

        //just for demo purposes...
        internal int EmployeeId {
            get {
                return _employeeId;
            }
        }

        public void ChangeName(string name) {
            _name = name;
        }

        public void ChangeAdress(string address) {
            _address = address;
        }

        public void SetEmployeeType(EmployeeType employeeType) {
            _employeeType = employeeType;
        }

        public void AddContact(Contact contact) {
            if (_contacts.Contains(contact)) {
                return;
            }
            _contacts.Add(contact);
        }

        public void RemoveContact(Contact contact) {
            _contacts.Remove(contact);
>>>>>>> e96e826d0fb5be89e7f6b512fd6afe010b3a8630
        }

        public override string ToString() {
            var str = new StringBuilder();
<<<<<<< HEAD
            str.AppendFormat("Funcionário {0} do tipo {3}, residente em {1}, possui o ID {2}\n", Name, Address,
                EmployeeId, EmployeeType);
            str.Append("Contactos: \n\n");
            foreach (var contacto in Contacts) {
=======
            str.AppendFormat("Funcionário {0} do tipo {3}, residente em {1}, possui o ID {2}\n", _name, _address,
                _employeeId, _employeeType);
            str.Append("Contactos: \n\n");
            foreach (var contacto in _contacts) {
>>>>>>> e96e826d0fb5be89e7f6b512fd6afe010b3a8630
                str.AppendFormat("{0}\n", contacto);
            }
            return str.ToString();
        }
    }
}