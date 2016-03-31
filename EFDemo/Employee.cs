using System.Collections.Generic;
using System.Text;

namespace EFDemo {

    //NOTE: set as partial for simplifying EF mappings
    public partial class Employee {
        private IList<Contact> Contacts { get; set; } 
        public int EmployeeId { get; private set; }
        private string Address { get; set; }
        private string Name { get; set; }
        private EmployeeType EmployeeType { get; set; }
        public byte[] Version { get; private set; }

        //just for demo purposes...

        public Employee() {
            Contacts = new List<Contact>();
        }


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
        }

        public override string ToString() {
            var str = new StringBuilder();

            str.AppendFormat("Funcionário {0} do tipo {3}, residente em {1}, possui o ID {2}\n", Name, Address,
                EmployeeId, EmployeeType);
            str.Append("Contactos: \n\n");
            foreach (var contacto in Contacts) {
                str.AppendFormat("{0}\n", contacto);
            }
            return str.ToString();
        }
    }
}