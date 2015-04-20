namespace WindowsFormsApplication1.model
{
    // Employee login, currently with hard-coded data
    internal class Employee
    {
        private readonly string employeeUserName;
        private readonly string employeePassword;
        private int employeeID;
        private string employeeFirstName;
        private string employeeLastName;

        public Employee(int IDnumber, string userName, string password, string firstName, string lastName)
        {
            this.employeeID = IDnumber;
            this.employeeUserName = userName;
            this.employeePassword = password;
            this.employeeFirstName = firstName;
            this.employeeLastName = lastName;
        }

        public string getUserName()
        {
            return this.employeeUserName;
        }

        public string getPassword()
        {
            return this.employeePassword;
        }
    }
}