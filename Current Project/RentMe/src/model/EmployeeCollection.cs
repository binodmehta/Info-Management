using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApplication1.model
{
    internal class EmployeeCollection
    {
        private readonly List<Employee> employeeList = new List<Employee>();
        private Employee employee1;
        private Employee employee2;
        private Employee employee3;
        private Employee employee4;
        private Employee employee5;

        public void populateList()
        {
            this.employee1 = new Employee(001, "dstamps1", "12345", "Daniel", "Stamps");
            this.employee2 = new Employee(002, "tholt4", "password1", "Terry", "Holt");
            this.employee3 = new Employee(003, "bpatterson1", "iloveandroid", "Bryan", "Patterson");
            this.employee4 = new Employee(004, "elatimer1", "sysarchishard", "Ethan", "Latimer");
            this.employee5 = new Employee(005, "dcofer2", "cookieclicker", "Daryl", "Cofer");
            this.employeeList.Add(this.employee1);
            this.employeeList.Add(this.employee2);
            this.employeeList.Add(this.employee3);
            this.employeeList.Add(this.employee4);
            this.employeeList.Add(this.employee5);
        }

        public bool checkLoginInfo(string userName, string password)
        {
            bool infoMatch = false;
            for (int i = 0; i < this.employeeList.Count; i++)
            {
                if (this.employeeList.ElementAt(i).getUserName().Equals(userName) &&
                    this.employeeList.ElementAt(i).getPassword().Equals(password))
                {
                    infoMatch = true;
                }
            }

            return infoMatch;
        }
    }
}