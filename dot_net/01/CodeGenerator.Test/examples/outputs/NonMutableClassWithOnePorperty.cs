using System;

namespace Company.Accounting
{
    /// <summary>
    /// Represents an employee
    /// </summary>
    public class Employee
    {
        private readonly string name;

        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public Employee(string name)
        {
            this.name = name;
        }
    }
}
