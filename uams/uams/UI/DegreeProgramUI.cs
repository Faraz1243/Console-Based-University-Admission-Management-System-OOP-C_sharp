using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using uams.DL;

namespace uams.UI
{
    class DegreeProgramUI
    {
        public static DegreeProgram inputDegree()
        {
            Console.Write("Enter Degree Name... ");
            string name = Console.ReadLine();
            Console.Write("Enter Degree Duration... ");
            float duration = float.Parse(Console.ReadLine());
            Console.Write("Enter Seats for Degree... ");
            int seats = int.Parse(Console.ReadLine());

            DegreeProgram d = new DegreeProgram(name, duration, seats);
            Console.Write("Enter Number of Preferences...");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                Subject s = SubjectUI.inputSubject();
                if (d.addSubject(s))
                {
                    if (!(SubjectDL.subjectList.Contains(s)))
                    {
                        SubjectDL.addSubjectToList(s);
                        SubjectDL.save("subject.txt", s);
                    }

                    Console.WriteLine("Subject Added Successfully! ");
                }
                else
                {
                    Console.WriteLine("Credit hours Exceeded");
                    x--;
                }
            }
            return d;      
        }
        public static void viewPrograms()
        {
            foreach (DegreeProgram dp in DegreeProgramDL.degreePrograms)
            {
                Console.WriteLine(dp.degreeName);
            }
        }
        public static string inputDegreeName()
        {
            Console.Write("Enter Degree Name... ");
            string name = Console.ReadLine();
            return name;
        }
    }
}
