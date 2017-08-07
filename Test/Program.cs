using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AHomeOfSelfDiscipline.Models;

namespace Test
{
    class Program
    {
        public enum TimeOfDay
        {
            Morning ,
            Afternoon,
            Evening 
        }

        static void Main()
        {
            WriteGreeting(TimeOfDay.Morning);
            WriteGreeting(TimeOfDay.Afternoon);
            WriteGreeting(TimeOfDay.Evening);
            Console.ReadLine();
        }
        static void WriteGreeting(TimeOfDay timeofday)
        {
            //switch用法  
            switch (timeofday)
            {
                case TimeOfDay.Morning:
                    Console.WriteLine("Good morning!");
                    break;
                case TimeOfDay.Afternoon:
                    Console.WriteLine("Good afternoon!");
                    break;
                case TimeOfDay.Evening:
                    Console.WriteLine("Good evening!");
                    break;
                default:
                    Console.WriteLine("Hello!");
                    break;
            }
        }
    }
}
