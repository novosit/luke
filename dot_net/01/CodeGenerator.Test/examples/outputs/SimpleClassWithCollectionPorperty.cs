using System;
using System.Collections.Generic;

namespace Company.Accounting
{
    /// <summary>
    /// Represents an employee
    /// </summary>
    public class Employee
    {
        private string id;
        private string name;
        private IList<string> pastPositions;

        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

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

        public IList<string> PastPositions
        {
            get
            {
                return this.pastPositions;
            }
            set
            {
                this.pastPositions = value;
            }
        }

        public Employee()
        {
        }
    }
}
