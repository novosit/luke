using System;

namespace CodeGenerator
{
        /// <summmary>
        /// This class definition is not supposed to make sense, just a mashup of all possible values in the input.
        /// </summary>
        internal class Person
        {
                private readonly Int32 id;
                private readonly float height;
                private readonly Double score;
                private readonly String name;
                private readonly System.Collections.Generic.IList<DateTime> dates;
                private readonly Boolean active;

                protected Int32 Id
                {
                        get { return id; }
                }

                private float Height
                {
                        get { return height; }
                }

                public Double Score
                {
                        get { return score; }
                }

                internal String Name
                {
                        get { return name; }
                }

                public System.Collections.Generic.IList<DateTime> Dates
                {
                        get { return dates; }
                }

                public Boolean Active
                {
                        get { return active; }
                }

                public Person(Int32 id, float height, Double score, String name, System.Collections.Generic.IList<DateTime> dates, Boolean active)
                {
                        this.id = id;
                        this.height = height;
                        this.score = score;
                        this.name = name;
                        this.dates = dates;
                        this.active = active;
                }
        }
}