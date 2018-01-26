using System;

namespace CodeGenerator
{
        /// <summmary>
        /// Represents a document within the EDMS repository
        /// </summary>
        public class Document
        {
                private readonly String handle;
                private readonly String name;
                private readonly System.Collections.Generic.IList<DateTime> dates;

                public String Handle
                {
                        get { return handle; }
                }

                public String Name
                {
                        get { return name; }
                }

                public System.Collections.Generic.IList<DateTime> Dates
                {
                        get { return dates; }
                }

                public Document(String handle, String name, System.Collections.Generic.IList<DateTime> dates)
                {
                        this.handle = handle;
                        this.name = name;
                        this.dates = dates;
                }
        }
}