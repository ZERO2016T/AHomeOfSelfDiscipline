using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Regex(@"^[1-9][0-9]{4,9}$").IsMatch("dd"));

           
        }
    }
}
