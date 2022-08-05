using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Text;
using System.Threading.Tasks;
using UAMS.DL;
using UAMS.BL;

namespace UAMS.UI
{
    internal class SubjectUI
    {
        public static int getID4registerSubject()
        {
            WriteLine("Enter Student ID ...");
            string id = (ReadLine());
            while (!int.TryParse(id, out int studentId))
            {
                WriteLine("Invalid ID");
                WriteLine("Enter Student ID ...");
                id = (ReadLine());
            }
            int ID = int.Parse(id);
            while (!StudentCRUD.studentAvailability(ID))
            {
                WriteLine("Invalid ID");
                WriteLine("Enter Student ID ...");
                id = (ReadLine());
                ID = int.Parse(id);
            }
            return ID;
        }
        public static string getCourse4registerSubject(int id)
        {
            WriteLine("Enter Course Code ...");
            string course = (ReadLine());
            while (!DegreeProgramCRUD.subjectValidation(id, course))
            {
                WriteLine("Invalid Course Code");
                WriteLine("Enter Course Code ...");
                course = (ReadLine());
            }
            return course;
        }
    }
}
