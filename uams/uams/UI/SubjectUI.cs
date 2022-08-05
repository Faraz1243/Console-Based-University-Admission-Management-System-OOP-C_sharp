using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using uams.DL;

namespace uams.UI
{
    class SubjectUI
    {
        public static void viewSubjects(Student s)
        {
            if (s.enrolledDegree != null)
            {
                Console.WriteLine("Code       Title");
                foreach (Subject sub in s.enrolledDegree.subjects)
                {
                    Console.WriteLine(sub.code + "\t\t" + sub.type);
                }
            }
        }
        public static Subject inputSubject()
        {
            Console.Write("Enter Code... ");
            string code = Console.ReadLine();
            Console.Write("Enter Type... ");
            string type = Console.ReadLine();
            Console.Write("Enter Credit Hours... ");
            int hours = int.Parse(Console.ReadLine());
            Console.Write("Enter Fees... ");
            int subjectFee = int.Parse(Console.ReadLine());
            Subject s = new Subject(code, type, hours, subjectFee);
            return s;
        }
        public static void registerSubjects(Student s)
        {
            Console.WriteLine("Enter how many Subjects to Register...");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                Console.WriteLine("Enter the subject Code...");
                string code = Console.ReadLine();
                bool b = false;
                foreach (Subject sub in s.enrolledDegree.subjects)
                {
                    if (code == sub.code && !(s.registeredSubjects.Contains(sub)))
                    {
                        if (s.registerSubject(sub))
                        {
                            b = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Max 9 Credit Hours Allowed!");
                            b = true;
                            break;
                        }
                    }
                }
                if (b == false)
                {
                    Console.WriteLine("Enter Valid Course");
                    x--;
                }
            }
        }
    }
}
