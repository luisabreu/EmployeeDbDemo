using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFDemo {
    public class Contact {
<<<<<<< HEAD
        private string Value { get; set; } = "";
        private ContactKind Kind { get; set; } = ContactKind.Phone;

        public Contact(string contact, ContactKind contactKind) {
            Value = contact;
            Kind = contactKind;
=======
        private string _contact = "";
        private ContactKind _contactKind = ContactKind.Phone;

        public Contact(string contact, ContactKind contactKind) {
            _contact = contact;
            _contactKind = contactKind;
>>>>>>> e96e826d0fb5be89e7f6b512fd6afe010b3a8630
        }

        private Contact() {
        }

        protected bool Equals(Contact other) {
<<<<<<< HEAD
            return string.Equals(Value, other.Value) && Kind == other.Kind;
=======
            return string.Equals(_contact, other._contact) && _contactKind == other._contactKind;
>>>>>>> e96e826d0fb5be89e7f6b512fd6afe010b3a8630
        }

        public override string ToString() {
            var str = new StringBuilder();
<<<<<<< HEAD
            str.AppendFormat("{0} do tipo {1}\n", Value, Kind);
=======
            str.AppendFormat("{0} do tipo {1}\n", _contact, _contactKind);
>>>>>>> e96e826d0fb5be89e7f6b512fd6afe010b3a8630
            return str.ToString();
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Contact) obj);
        }

        public override int GetHashCode() {
            unchecked {
<<<<<<< HEAD
                return ((Value != null ? Value.GetHashCode() : 0)*397) ^ (int) Kind;
=======
                return ((_contact != null ? _contact.GetHashCode() : 0)*397) ^ (int) _contactKind;
>>>>>>> e96e826d0fb5be89e7f6b512fd6afe010b3a8630
            }
        }

        public static bool operator ==(Contact left, Contact right) {
            return Equals(left, right);
        }

        public static bool operator !=(Contact left, Contact right) {
            return !Equals(left, right);
        }
    }
}