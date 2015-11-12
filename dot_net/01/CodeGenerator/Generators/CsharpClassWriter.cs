using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.Utils;




namespace CodeGenerator.Generators
{
    
    public class CsharpClassWriter
    {
        private ClassModel model;
        private string output;
        private int identSpaces = 4;
        private char identChar = ' ';
        private char returnChar = '\n';
        public CsharpClassWriter(ClassModel Model, int identSpaces = 4, char indentChar = ' ')
        {            
            this.model = Model;
        }

        public string GenerateClass()
        {
            string usingSection = GenerateUsingSection(model);
            string classNameSection = GenerateClassNameSection(model);
            string privateFieldsSection = GeneratePrivateFieldsSection(model.Properties, model);
            string publicPropertiesSection = GeneratePublicPropertiesSection(model);
            string constructorSection = GenerateContructorSection(model);

            this.WriteLine(usingSection);
            this.WriteLine(classNameSection);
            this.WriteLine(privateFieldsSection);
            this.WriteLine(publicPropertiesSection);
            this.WriteLine(constructorSection);
            this.WriteCloseClassSection();            

            return output;
        }

      
        private string GenerateUsingSection(ClassModel model)
        {
            string value = "";
            value += CreateNewLine("using System;");
            if (model.Properties.Where(prop => prop.Cardinality == "many").Count() > 0)
            {
                value += CreateNewLine("using System.Collections.Generic;");
            }
            return value;
        }

        private string GenerateClassNameSection(ClassModel model)
        {
            string value = "";
            string _namespace = string.IsNullOrEmpty(model.Namespace)? model.Name: model.Namespace;


            value += CreateNewLine(string.Format("namespace {0}", _namespace));
            value += CreateNewLine("{");
            value += GenerateSummary(model.Description, 1);
            value += CreateNewLine(string.Format("public class {0}", model.Name)).CustomPadLeft(identSpaces, identChar);
            value += CreateNewLine("{".CustomPadLeft(identSpaces, identChar));
            return value;
        }

        private string GenerateSummary(string description, int identMultiplier =0)
        {
            string value = "";
            if (!string.IsNullOrEmpty(description))
            {
                value += CreateNewLine("/// <summary>").CustomPadLeft(identSpaces * identMultiplier, identChar);
                value += CreateNewLine(string.Format("/// {0}", description)).CustomPadLeft(identSpaces * identMultiplier, identChar);
                value += CreateNewLine("/// </summary>").CustomPadLeft(identSpaces * identMultiplier, identChar);
            }
         
            return value;
        }
        
        private string GeneratePrivateFieldsSection(List<Property> properties, ClassModel model)
        {
            string value = "";
            foreach (var property in properties)
            {
                string accesModifer = GetAccesModifier(property, model);
                string type = GetPropertyType(property);
                value += CreateNewLine(string.Format("private {0}{1} {2};", accesModifer, type, property.Name.ToInitialLower()))
                    .CustomPadLeft(identSpaces * 2, identChar); 
            }
            return value;
        }

        private string GetAccesModifier(Property property, ClassModel model)
        {
            string modifer = "";

            if (!model.Mutable)
            {
                modifer = "readonly ";
            }

            if (property.Mutable != null && !(bool)property.Mutable)
            {
                modifer = "readonly ";
            }

            return modifer;
        }

        private string GetPropertyType(Property property)
        {
          return  property.Cardinality == "many" ? string.Format("IList<{0}>", property.Type) : property.Type;
        }

        private string GeneratePublicPropertiesSection(ClassModel model)
        {
            string value = "";
            foreach (var property in model.Properties)
            {
                if(!string.IsNullOrEmpty( property.Description))
                {
                    value += value += GenerateSummary(property.Description, 2);
                }

                string type = GetPropertyType(property);
                
                value += CreateNewLine(string.Format("public {0} {1}", type, property.Name.ToInitialUpper()))
                    .CustomPadLeft(identSpaces * 2, identChar);                
                value += CreateNewLine("{").CustomPadLeft(identSpaces * 2, identChar);
                
                value += GenerateGetPropertySection(property);
                value += GenerateSetPropertySection(property);               

                value += CreateNewLine("}").CustomPadLeft(identSpaces * 2, identChar);
            }
            return value;
        }

        private string GenerateGetPropertySection(Property property)
        {
            string value = "";

            value += CreateNewLine("get").CustomPadLeft(identSpaces * 3, identChar);
            value += CreateNewLine("{").CustomPadLeft(identSpaces * 3, identChar);
            value += CreateNewLine(string.Format("return this.{0};", property.Name.ToInitialLower()))
                .CustomPadLeft(identSpaces * 4, identChar);
            value += CreateNewLine("}").CustomPadLeft(identSpaces * 3, identChar);

            return value;
        }

        private string GenerateSetPropertySection(Property property)
        {
            string value = "";
      
            if (!model.Mutable)
            {
               return value;
            }

            if (property.Mutable != null && !(bool)property.Mutable)
            {
                return value;
            }

            value += CreateNewLine("set").CustomPadLeft(identSpaces * 3, identChar);
            value += CreateNewLine("{").CustomPadLeft(identSpaces * 3, identChar);
            value += CreateNewLine(string.Format("this.{0} = value;", property.Name.ToInitialLower()))
                .CustomPadLeft(identSpaces * 4, identChar);
            value += CreateNewLine("}").CustomPadLeft(identSpaces * 3, identChar);

            return value;
        }

        private string GenerateContructorSection(ClassModel model)
        {
            string value = CreateNewLine(string.Format("public {0}(", model.Name).CustomPadLeft(identSpaces * 2, identChar));
         
            List<Property> nonMutableproperties = new List<Property>();
            if (!model.Mutable)
            {
                nonMutableproperties.AddRange(model.Properties);
            }
            else
            {
                nonMutableproperties.AddRange(
                    model.Properties.Where(prop => prop.Mutable != null && !(bool)prop.Mutable)
                    );
            }

            for (var i = 0; i < nonMutableproperties.Count; i++)
            {
                var property = nonMutableproperties[i];
                string type = GetPropertyType(property);

                value += i > 0 ? " " : ""; 
                value += string.Format("{0} {1}", type, nonMutableproperties[i].Name.ToInitialLower());

                if (i < nonMutableproperties.Count - 1)
                {
                    value += ",";
                }
            }

            value += CreateNewLine(")");
            value += CreateNewLine("{").CustomPadLeft(identSpaces * 2, identChar);

            value += GenereateConstructorBody(nonMutableproperties);

            value += CreateNewLine("}").CustomPadLeft(identSpaces * 2, identChar);

            return value;
        }  
          
        private string GenereateConstructorBody(List<Property> properties)
        {
            string value = "";
            foreach (var property in properties)
            {
                value += CreateNewLine(string.Format("this.{0} = {1};",
                    property.Name.ToInitialLower(),
                    property.Name.ToInitialLower()
                    )).CustomPadLeft(identSpaces * 3, identChar);
            }
            return value;
        }

        private void WriteLine(string value)
        {
            this.output += value + returnChar ;
        }

        private string CreateNewLine(string value)
        {
            return value + "\n";
        }

        private void WriteCloseClassSection()
        {
            this.WriteLine("}".CustomPadLeft(identSpaces,identChar));
            this.WriteLine("}");
        }
    }
}
