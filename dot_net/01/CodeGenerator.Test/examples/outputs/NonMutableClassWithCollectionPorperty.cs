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
        private readonly IList<string> pastPositions;

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
        }

        public Employee(string id, string name, IList<string> pastPositions)
        {
            this.id = id;
            this.name = name;
            this.pastPositions = pastPositions;
        }
    }
}
