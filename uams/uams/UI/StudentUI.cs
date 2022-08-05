using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using uams.DL;
using uams.BL;

namespace uams.UI
{
    class StudentUI
    {
        public static Student inputForStudent()
        {
            ConsoleUI.header();
            List<DegreeProgram> preferences = new List<DegreeProgram>();
            Write("Enter Name... ");
            string name = ReadLine();
            Write("Enter Age... ");
            int age = int.Parse(ReadLine());
            Write("Enter FSc Marks... ");
            double FSc = double.Parse(ReadLine());
            Write("Enter Ecat Marks... ");
            double ECAT = double.Parse(ReadLine());
            WriteLine("======Offered Degree Programs======");
            DegreeProgramUI.viewPrograms();

            Write("Enter how many Preferences to Enter... ");
            int Count = int.Parse(ReadLine());
            for (int x = 0; x < Count; x++)
            {
                string title = ReadLine();
                bool b = false;
                foreach (DegreeProgram dp in DegreeProgramDL.degreePrograms)
                {
                    if (title == dp.degreeName && !(preferences.Contains(dp)))
                    {
                        preferences.Add(dp);
                        b = true;
                    }

                }
                if (b == false)
                {
                    WriteLine("Enter Valid Name!");
                    x--;
                }
            }
            Student s = new Student(name, age, FSc, ECAT, preferences);
            return s;

        }
        public static void studentOfProgram(string degName)
        {
            WriteLine("Name\tFSC\tEcat\tAge");
            foreach (Student s in StudentDL.studentList)
            {
                if (s.enrolledDegree != null)
                {
                    if (degName == s.enrolledDegree.degreeName)
                    {
                        WriteLine(s.name + "\t" + s.FSc + "\t" + s.ECAT + "\t" + s.age);
                    }
                }
            }
        }
        public static void registeredStudents()
        {
            WriteLine("Name\tFSc\tEcat\tAge");
            foreach (Student s in StudentDL.studentList)
            {
                if (s.enrolledDegree != null)
                {
                    WriteLine(s.name + "\t" + s.FSc + "\t" + s.ECAT + "\t" + s.age);
                }
            }
        }
        public static void calculateFee()
        {
            foreach (Student s in StudentDL.studentList)
            {
                if (s.enrolledDegree != null)
                {
                    WriteLine(s.name + "\t\t\t" + s.calculateFee() );
                }
            }
        }
        public static void printAdmittedStudents()
        {
            foreach (Student s in StudentDL.studentList)
            {
                if (s.enrolledDegree != null)
                {
                    WriteLine(s.name + " got Admitted in " + s.enrolledDegree.degreeName);
                }
            }
        }
        public static string getName()
        {
            ConsoleUI.header();
            Write("Enter Name... ");
            string name = ReadLine();
            return name;
        }
    }
}
