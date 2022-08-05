using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace uams.UI
{
    class ConsoleUI
    {
        public static void header()
        {
            Clear();
            WriteLine("********************************************");
            WriteLine("*                   UAMS                   *");
            WriteLine("********************************************");
        }
        public static int mainMenu()
        {
            header();
            int opt =0;
            WriteLine("1-  Add Student ");
            WriteLine("2-  Add Degree Program ");
            WriteLine("3-  Generate Merit ");
            WriteLine("4-  View Registered Students ");
            WriteLine("5-  View Students of a Specific Program ");
            WriteLine("6-  Register Subjects for a Specific Student ");
            WriteLine("7-  Calculate Fees for all Registered Students ");
            WriteLine("8-  Exit ");
            Write("Your Option... ");
            opt = int.Parse(ReadLine());
            return opt;
        }
        public static void noDegreePrograms()
        {
            WriteLine("No Degree Programs Available!");
            ReadKey();
        }
    }
}
