using System;
using System.Collections.Generic;

namespace Company.Accounting
{
    /// <summary>
    /// Represents an employee
    /// </summary>
    public class Employee
    {
        private readonly string id;
        private readonly string name;
        private IList<string> pastPositions;

        public string Id
        {
            get
            {
                return this.id;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
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

        public Employee(string id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
