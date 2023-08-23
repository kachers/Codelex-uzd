namespace Firm
{
    public abstract class StaffMember
    {
        private string _name;
        private string _address;
        private string _phone;

        protected StaffMember(string name, string address, string phone) 
        {
            _name = name;
            _address = address;
            _phone = phone;
        }

        public override string ToString() 
        {
            var result = "Name: " + _name + "\n";
            result += "Address: " + _address + "\n";
            result += "Phone: " + _phone;
            return result;
        }

        public abstract double Pay();
    }
}