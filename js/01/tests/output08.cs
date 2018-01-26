using System;

namespace CodeGenerator
{
        /// <summmary>
        /// This class definition is not supposed to make sense, just a mashup of all possible values in the input.
        /// </summary>
        internal class Person
        {
                private readonly String name;

                protected Int32 Id { get; set; }

                private float Height { get; set; }

                public Double Score { get; set; }

                internal String Name
                {
                        get { return name; }
                }

                public System.Collections.Generic.IList<DateTime> Dates { get; set; }

                public Boolean Active { get; set; }

                public Person(String name)
                {
                        this.name = name;
                }
        }
}