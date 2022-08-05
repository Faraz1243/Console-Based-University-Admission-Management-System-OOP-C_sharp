using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UAMS.BL;
using UAMS.DL;
using UAMS.UI;

namespace UAMS.DL
{
    internal class DegreeProgramCRUD
    {
        public static List<DegreeProgram> DegreePrograms = new List<DegreeProgram>();
        public static void generateMerit()
        {
            //bubble sort for applicants
            for (int i = 0; i < StudentCRUD.students.Count; i++)
            {
                for (int j = 0; j < StudentCRUD.students.Count - 1; j++)
                {
                    if (StudentCRUD.students[j].merit() < StudentCRUD.students[j + 1].merit())
                    {
                        Student temp = StudentCRUD.students[j];
                        StudentCRUD.students[j] = StudentCRUD.students[j + 1];
                        StudentCRUD.students[j + 1] = temp;
                    }
                }
            }
            while (!meritCalculationCompletionDetector())
            {
                //filling admitted students list in every degree program
                foreach (DegreeProgram d in DegreeProgramCRUD.DegreePrograms)
                {
                    int st_counter = 0;
                    while (d.availableSeats > d.enrolledStudents.Count)
                    {
                        if (d.programTitle == StudentCRUD.students[st_counter].preferences[0])
                        {
                            d.enrolledStudents.Add(StudentCRUD.students[st_counter]);
                            StudentCRUD.students.RemoveAt(st_counter);
                            st_counter--;
                        }
                        st_counter++;
                        //to break while loop in case of no more students
                        if (st_counter == StudentCRUD.students.Count)
                        {
                            break;
                        }
                    }
                    //if all seats are filled of a degree program
                    foreach (Student s in StudentCRUD.students)
                    {
                        foreach (string p in s.preferences)
                        {
                            if (p == d.programTitle)
                            {//if all seats of a program are filled, then its presence in prefeerences will b eradicated
                                s.preferences.Remove(p);
                                break;
                            }
                        }
                    }
                }
            }

        }
        public static bool degreeProgramValidation(string name)
        {
            bool b = false;
            foreach (DegreeProgram dp in DegreeProgramCRUD.DegreePrograms)
            {
                if (name == dp.programTitle)
                {
                    b = true;
                }
            }
            return b;
        }
        public static bool meritCalculationCompletionDetector()
        {
            foreach (DegreeProgram dp in DegreeProgramCRUD.DegreePrograms)
            {
                if (dp.enrolledStudents.Count == dp.availableSeats)
                {//if a program seats are filled then this round of loop is skipped
                    break;
                }
                else
                {// to check if there is any student willing to opt for ccurrent program while seats are not filled
                    foreach (Student s in StudentCRUD.students)
                    {
                        foreach (string p in s.preferences)
                        {
                            if (p == dp.programTitle)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public static DegreeProgram getDegree(int rollNo)
        {
            foreach (DegreeProgram dp in DegreeProgramCRUD.DegreePrograms)
            {
                foreach (Student s in dp.enrolledStudents)
                {
                    if (s.studentId == rollNo)
                    {
                        return dp;
                    }
                }
            }
            return null;
        }
        public static bool subjectValidation(int id, string course)
        {
            DegreeProgram dp = DegreeProgramCRUD.getDegree(id);
            List<Subject> sub = dp.getSubjects();
            foreach (Subject s in sub)
            {
                if (s.subjectCode == course)
                {
                    return true;
                }
            }
            return false;
        }
        public static Subject getSubject(string id)
        {
            foreach (DegreeProgram d in DegreePrograms)
            {
                foreach (Subject subject in d.offeredSubjects)
                {
                    if (subject.subjectCode == id)
                    {
                        return subject;
                    }
                }
            }
            return null;
        }

        public static void saveSubjects()
        {
            string path = "subjects.txt";
            StreamWriter file = new StreamWriter(path);
            foreach (DegreeProgram d in DegreePrograms)
            {
                foreach (Subject s in d.offeredSubjects)
                {
                    file.WriteLine(s.subjectCode + "," + s.subjectCreditHours + "," + s.subjectType + "," + s.subjectFee);
                }
            }
            file.Flush();
            file.Close();
        }
        //public static void loadSubjects()
        //{
        //    string path = "subjects.txt";
        //    StreamReader file = new StreamReader(path);
        //    string line = file.ReadLine();
        //    while (line != null)
        //    {
        //        string[] data = line.Split(',');
        //        Subject s = new Subject(data[0], data[1], data[2], data[3]);
        //        foreach (DegreeProgram d in DegreePrograms)
        //        {
        //            if (d.programTitle == s.subjectType)
        //            {
        //                d.offeredSubjects.Add(s);
        //            }
        //        }
        //        line = file.ReadLine();
        //    }
        //    file.Close();
        //}
        public static void saveDegrees()
        {
            string path = "degrees.txt";
            StreamWriter file = new StreamWriter(path);
            foreach (DegreeProgram d in DegreePrograms)
            {
                file.WriteLine(d.programTitle + "," + d.programTitle + "," + d.availableSeats);
                foreach (Subject s in d.offeredSubjects)
                {
                    file.Write(s.subjectCode + ",");
                }
                file.WriteLine();
                foreach (Student s in d.enrolledStudents)
                {
                    file.Write(s.studentId + ",");
                }
                file.WriteLine();
            }
            file.Flush();
            file.Close();
        }
        
  
    }
}
