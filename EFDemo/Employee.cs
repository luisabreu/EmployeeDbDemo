using System.Collections.Generic;
using System.Text;

namespace EFDemo {
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
        }

        public override string ToString() {
            var str = new StringBuilder();
            str.AppendFormat("Funcionário {0} do tipo {3}, residente em {1}, possui o ID {2}\n", _name, _address,
                _employeeId, _employeeType);
            str.Append("Contactos: \n\n");
            foreach (var contacto in _contacts) {
                str.AppendFormat("{0}\n", contacto);
            }
            return str.ToString();
        }
    }
}