using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.UI
{
    internal class MainUI
    {
        public static void header()
        {
            Console.Clear();
            Console.WriteLine("===================================================");
            Console.WriteLine("=                       UAMS                      =");
            Console.WriteLine("===================================================");
        }
        public static string userOption()
        {
            header();
            Console.WriteLine("1- Add Student");
            Console.WriteLine("2- Add Degree Program");
            Console.WriteLine("3- Generate Merit");
            Console.WriteLine("4- View Registered Students");
            Console.WriteLine("5- View Students of Specific Program");
            Console.WriteLine("6- Register Subjects for Specific Student");
            Console.WriteLine("7- Calculate Fee for All Registered Students");
            Console.WriteLine("8- Exit");
            string option = Console.ReadLine();
            return option;
        }
        public static void printFee(string name, int id, int fee)
        {
            Write(name);
            Write("\t\t\t");
            Write(id);
            Write("\t\t\t");
            Write(fee);
            Write("\n");
        }
        public static void popup(string s)
        {
            WriteLine(s);
        }
    }
}
