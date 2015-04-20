using System.Collections.Generic;

namespace WindowsFormsApplication1.model
{
    internal class CustomerCollection
    {
        private readonly List<Customer> customerList = new List<Customer>();

        public void addCustomer(Customer customerToAdd)
        {
            this.customerList.Add(customerToAdd);
        }
    }
}