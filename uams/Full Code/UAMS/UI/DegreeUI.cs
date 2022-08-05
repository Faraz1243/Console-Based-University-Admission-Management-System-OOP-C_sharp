using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using UAMS.DL;

namespace UAMS.UI
{
    internal class DegreeUI
    {
        public static DegreeProgram addDegreeProgram()
        {
            List<Subject> subjects = new List<Subject>();
            //===========interface============
            // for entries
            MainUI.header();
            Console.WriteLine("Enter Program Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Program Duration");
            string duration = Console.ReadLine();
            Console.WriteLine("Enter Available Seats");
            int seats = int.Parse(Console.ReadLine());


            //===========interface============
            // for list
            while (true)
            {
                MainUI.header();
                Console.WriteLine("Enter Subject Code");
                string subjectTitle = Console.ReadLine();
                Console.WriteLine("Enter Subject Credit Hours");
                int subjectCreditHours = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Subject Type");
                string subjectType = Console.ReadLine();
                Console.WriteLine("Enter Subject Fee");
                int subjectFee = int.Parse(Console.ReadLine());
                //create Subject type object
                Subject subject = new Subject(subjectTitle, subjectCreditHours, subjectType, subjectFee);
                //add subject to list
                subjects.Add(subject);
                Console.WriteLine("Do you want to add another subject? (y/n)");
                string answer = Console.ReadLine();
                if (answer == "y" || answer == "Y")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            //===========processing============
            DegreeProgram program = new DegreeProgram(name, duration, seats, subjects);
            Console.WriteLine("Program added successfully");
            Console.ReadKey();
            return program;
        }
        public static void printMerit()
        {
            foreach (DegreeProgram d in DegreeProgramCRUD.DegreePrograms)
            {
                Write(d.programTitle);
                Write("\t\t\t");
                WriteLine(d.getMerit());
            }
        }
        public static void viewRegisteredStudents()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Name");
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("ID");
            Console.SetCursorPosition(40, 0);
            Console.WriteLine("Age");
            int counter = 1;
            foreach (DegreeProgram d in DegreeProgramCRUD.DegreePrograms)
            {
                foreach (Student s in d.enrolledStudents)
                {
                    Console.SetCursorPosition(0, counter);
                    Console.WriteLine(s.name);
                    Console.SetCursorPosition(20, counter);
                    Console.WriteLine(s.studentId);
                    Console.SetCursorPosition(40, counter);
                    Console.WriteLine(s.age);
                    if (counter == 10)
                    {
                        counter = counter / 10;
                        Console.ReadKey();
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Name");
                        Console.SetCursorPosition(20, 0);
                        Console.WriteLine("ID");
                        Console.SetCursorPosition(40, 0);
                        Console.WriteLine("Age");
                    }
                    counter++;
                }
            }
        }
        public static void studentsOfDegreePrograms()
        {
            Console.WriteLine("Enter Program Name");
            string name = Console.ReadLine();
            while (!DegreeProgramCRUD.degreeProgramValidation(name))
            {
                Console.WriteLine("Invalid Program Name");
                Console.WriteLine("Enter Program Name");
                name = Console.ReadLine();
            }


            DegreeProgram program = DegreeProgramCRUD.DegreePrograms.Find(x => x.programTitle == name);


            //print all students of list in program
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Name");
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("ID");
            Console.SetCursorPosition(40, 0);
            Console.WriteLine("Age");
            Console.SetCursorPosition(60, 0);
            Console.WriteLine("ECAT");
            Console.SetCursorPosition(80, 0);
            Console.WriteLine("FSC");
            int counter = 1;
            foreach (Student s in program.enrolledStudents)
            {
                Console.SetCursorPosition(0, counter);
                Console.WriteLine(s.name);
                Console.SetCursorPosition(20, counter);
                Console.WriteLine(s.studentId);
                Console.SetCursorPosition(40, counter);
                Console.WriteLine(s.age);
                Console.SetCursorPosition(60, counter);
                Console.WriteLine(s.ecat);
                Console.SetCursorPosition(80, counter);
                Console.WriteLine(s.fsc);
                counter++;
                if (counter == 10)
                {
                    counter = counter / 10;
                    Console.ReadKey();
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Name");
                    Console.SetCursorPosition(20, 0);
                    Console.WriteLine("ID");
                    Console.SetCursorPosition(40, 0);
                    Console.WriteLine("Age");
                    Console.SetCursorPosition(60, 0);
                    Console.WriteLine("ECAT");
                    Console.SetCursorPosition(80, 0);
                    Console.WriteLine("FSC");
                }
            }
        }
    }
}
