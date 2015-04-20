namespace WindowsFormsApplication1.model
{
    internal class Customer
    {
        private int custID;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private int ssn;
        private string streetAddress;
        private string cityAddress;
        private string stateAddress;
        private int zipCode;

        public Customer(int ID, string fName, string lName, int ssn, string phone, string street, string city,
            string state, int zip)
        {
            this.custID = ID;
            this.firstName = fName;
            this.lastName = lName;
            this.ssn = ssn;
            this.phoneNumber = phone;
            this.streetAddress = street;
            this.cityAddress = city;
            this.stateAddress = state;
            this.zipCode = zip;
        }
    }
}