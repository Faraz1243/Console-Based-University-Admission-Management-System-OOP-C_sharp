using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using System.IO;

namespace uams.DL
{
    class StudentDL
    {
        public static List<Student> studentList = new List<Student>();

        public static void addStudent(Student s)
        {
            studentList.Add(s);
        }
        public static Student StudentPresent(string name)
        {
            foreach (Student st in studentList)
            {
                if (name == st.name && st.enrolledDegree != null)
                {
                    return st;
                }
            }
            return null;
        }
        public static List<Student> sortStudentsByMerit()
        {
            List<Student> sortedList = new List<Student>();
            sortedList = studentList.OrderByDescending(o => o.getMerit()).ToList();
            return sortedList;
        }
        public static void giveAdmission(List<Student> sortedStudentList)
        {
            foreach (Student st in sortedStudentList)
            {
                foreach (DegreeProgram d in st.preferences)
                {
                    if (d.availableSeats > 0 && st.enrolledDegree == null)
                    {
                        st.enrolledDegree = d;
                        d.availableSeats--;
                        break;
                    }
                }
            }
        }
        public static void save(string path, Student s)
        {
            StreamWriter sw = new StreamWriter(path, true);
            string degreeNames = "";
            for(int x = 0; x < s.preferences.Count - 1; x++)
            {
                degreeNames  += s.preferences[x].degreeName + ";";
            }
            degreeNames += s.preferences[s.preferences.Count - 1].degreeName;
            sw.WriteLine(s.name + "," + s.age + "," + s.FSc + "," + s.ECAT + "," + degreeNames);
            sw.Flush();
            sw.Close();
        }
        public static void load()
        {
            StreamReader f = new StreamReader("students.txt");
            string record;
            if (File.Exists("students.txt"))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    int age = int.Parse(splittedRecord[1]);
                    double fscMarks = double.Parse(splittedRecord[2]);
                    double ecatMarks = double.Parse(splittedRecord[3]);
                    string[] splittedRecordForPreference = splittedRecord[4].Split(';');
                    List<DegreeProgram> preferences = new List<DegreeProgram>();

                    for (int x = 0; x < splittedRecordForPreference.Length; x++)
                    {
                        DegreeProgram d = DegreeProgramDL.isDegreeExists(splittedRecordForPreference[x]);
                        if (d != null)
                        {
                            if (!(preferences.Contains(d)))
                            {
                                preferences.Add(d);
                            }
                        }
                    }
                    Student s = new Student(name, age, fscMarks, ecatMarks, preferences);
                    studentList.Add(s);
                }
                f.Close();
            }
        }


    }
}
