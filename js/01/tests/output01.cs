using System;

namespace Company.Accounting
{
        /// <summmary>
        /// Represents an employee
        /// </summary>
        public class Employee
        {
                private readonly String id;
                private readonly String name;

                /// <summmary>
                /// Employee's unique Identifier
                /// </summary>
                public String Id
                {
                        get { return id; }
                }

                public String Name
                {
                        get { return name; }
                }

                public Employee(String id, String name)
                {
                        this.id = id;
                        this.name = name;
                }
        }
}