using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFDemo {
    public class Contact {

        private string Value { get; set; } 
        private ContactKind Kind { get; set; } 

        public Contact(string contact, ContactKind contactKind) {
            Value = contact;
            Kind = contactKind;
        }

        private Contact() :this("", ContactKind.Phone){
        }

        protected bool Equals(Contact other) {
            return string.Equals(Value, other.Value) && Kind == other.Kind;
        }

        public override string ToString() {
            var str = new StringBuilder();
            str.AppendFormat("{0} do tipo {1}\n", Value, Kind);
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
                return ((Value != null ? Value.GetHashCode() : 0)*397) ^ (int) Kind;
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