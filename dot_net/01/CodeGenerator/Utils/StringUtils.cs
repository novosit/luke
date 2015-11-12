using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Utils
{
    static class StringUtils
    {
        /// <summary>
        /// Returns a new string that right-aligns the characters in this instance by padding them with spaces on the left, for a specified total length.
        /// </summary>        
        /// <param name="width">The number o characters to add to the original string</param>
        /// <param name="paddingChar">The character to add to the original string</param>
        /// <returns></returns>
        public static string CustomPadLeft(this string value, int width, char paddingChar)
        {
            return value.PadLeft(value.Length + width, paddingChar);
        }

        public static string ToInitialLower(this string value)
        {
            return value[0].ToString().ToLowerInvariant() + value.Substring(1);
        }

        public static string ToInitialUpper(this string value)
        {
            return value[0].ToString().ToUpperInvariant() + value.Substring(1);
        }
       
    }
}
