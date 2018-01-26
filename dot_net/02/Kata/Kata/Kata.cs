using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Novosit
{
    public static class Kata
    {
        private static readonly String[] DELIMETERS =
        {
            ",",
            "\r\n",
            "\n\r",
            "\r",
            "\n",
            "\\n",
            "\\\\n"
        };

        public static Int32 Add(String input)
        {
            if (String.IsNullOrEmpty(input))
                return 0;

            // TODO actually get custom delimter with regex
            String customDelimeter = ";";
            var matches = Regex.Match(input, @"(\/\/(.*?))+(\n|\\n|\r\n|\n\r)", RegexOptions.Multiline);
            if (matches.Success)
                customDelimeter = matches.Groups[2].Value;

            String[] numbers = Regex.Split(input, String.Join("|", Kata.DELIMETERS) + "|" + customDelimeter);

            Int32 sum = 0;
            List<String> negatives = new List<String>();
            foreach (var item in numbers)
            {
                int n;
                var parsed = Int32.TryParse(item, out n);

                if (!parsed)
                    continue;

                sum += n;

                if (n < 0)
                    negatives.Add(item);
            }

            if (negatives.Count > 0)
                throw new Exception("negatives not allowed {" + String.Join(",", negatives) + "}");

            return sum;
        }
    }
}
