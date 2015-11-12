using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator.Generators;
using CodeGenerator.Utils;


namespace CodeGenerator
{
    public class Parser
    {
        public string GenerateClass(string json)
        {
            try
            {
                if (!ValidateInput(json))
                    return "Invalid input!";

                ClassModel model = json.FromJSON<ClassModel>();

                if (!ValidateInput(model))
                    return "Invalid input!";

                CsharpClassWriter generator = new CsharpClassWriter(model);

                return generator.GenerateClass();
            }
            catch (Newtonsoft.Json.JsonException ex)
            { 
                return "There was an error reading the input";
            }
            catch (Exception)
            {

                return "There was an error generating your ouput code";
            }
        }

        private bool ValidateInput(ClassModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
                return false;

            if (model.Properties != null)
            {
                var invalidProperties = model.Properties.Where(prop => string.IsNullOrEmpty(prop.Name));
                if (invalidProperties.Count() > 0)
                    return false;

                invalidProperties = model.Properties.Where(prop => string.IsNullOrEmpty(prop.Type));
                if (invalidProperties.Count() > 0)
                    return false;
            }
            
            return true;
        }

        private bool ValidateInput(string json)
        {
            if (string.IsNullOrEmpty(json))
                return false;

            if (!json.StartsWith("{") && !json.EndsWith("}"))
                return false;

            return true;
        }
    }
}
