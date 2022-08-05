using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using UAMS.UI;

namespace UAMS.DL
{
    internal class StudentCRUD
    {
        public static List<Student> students = new List<Student>();
        public static bool preferenceValidation(string pref, List<string> Temp)
        {
            bool b = false;
            foreach (DegreeProgram dp in DegreeProgramCRUD.DegreePrograms)
            {
                if (pref == dp.programTitle)
                {
                    b = true;
                }
            }
            foreach (string s in Temp)
            {
                if (pref == s)
                {
                    b = false;
                }
            }
            return b;
        }
        public static void calculateFee()
        {
            foreach(Student s in students)
            {
                MainUI.printFee(s.name, s.studentId, s.getFees());
            }
        }
        public static bool studentAvailability(int id)
        {
            foreach (DegreeProgram d in DegreeProgramCRUD.DegreePrograms)
            {
                foreach (Student s in d.enrolledStudents)
                {
                    if (s.studentId == id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static Student getStudent(int id)
        {
            foreach (Student s in students)
            {
                if (s.studentId == id)
                {
                    return s;
                }
            }
            return null;
        }
        public static void saveStudents()
        {
            string path = "students.txt";
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);
            foreach (Student s in students)
            {
                file.WriteLine(s.studentId + "," + s.name + "," + s.age + "," + s.ecat + "," + s.fsc);
                foreach (string p in s.preferences)
                {
                    file.Write(p);
                }
                file.WriteLine();
                foreach (Subject sub in s.registeredSubjects)
                {
                    file.Write(sub.subjectCode + ",");
                }
                file.WriteLine();
            }
            file.Flush();
            file.Close();
        }
    }
}
