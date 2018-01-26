using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novosit
{
    class Program
    {
        static void Main(string[] args)
        {
            String line, input = "";
            while ((line = Console.ReadLine()) != null)
            {
                input += line + "\r\n";
            }
            Console.WriteLine( Kata.Add(input) );
        }
    }
}
