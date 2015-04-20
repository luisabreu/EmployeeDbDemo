using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFDemo {
    public class Contact {
        private string _contact = "";
        private ContactKind _contactKind = ContactKind.Phone;

        public Contact(string contact, ContactKind contactKind) {
            _contact = contact;
            _contactKind = contactKind;
        }

        private Contact() {
        }

        protected bool Equals(Contact other) {
            return string.Equals(_contact, other._contact) && _contactKind == other._contactKind;
        }

        public override string ToString() {
            var str = new StringBuilder();
            str.AppendFormat("{0} do tipo {1}\n", _contact, _contactKind);
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
                return ((_contact != null ? _contact.GetHashCode() : 0)*397) ^ (int) _contactKind;
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