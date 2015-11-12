using System;

namespace Company.Accounting
{
    /// <summary>
    /// Represents an employee
    /// </summary>
    public class Employee
    {
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public Employee()
        {
        }
    }
}
