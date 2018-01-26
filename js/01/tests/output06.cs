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

                public String Handle
                {
                        get { return handle; }
                }

                public String Name
                {
                        get { return name; }
                }

                public Document(String handle, String name)
                {
                        this.handle = handle;
                        this.name = name;
                }
        }
}