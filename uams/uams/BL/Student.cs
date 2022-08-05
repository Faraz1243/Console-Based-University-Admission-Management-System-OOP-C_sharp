using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uams.BL
{
    class Student
    {
        public string name;
        public int age;
        public double FSc;
        public double ECAT;
        public List<DegreeProgram> preferences;
        public List<Subject> registeredSubjects;
        public DegreeProgram enrolledDegree;
        
        public Student(string name, int age, double FSc, double ECAT, List<DegreeProgram> preferences)
        {
            this.name = name;
            this.age = age;
            this.FSc = FSc;
            this.ECAT = ECAT;
            this.preferences = preferences;
            registeredSubjects = new List<Subject>();
            
        }
        
        public double getMerit()
        {
            return (((FSc / 1100) * 0.6) + ((ECAT / 400) * 0.4)) * 100;
        }
        public int getCreditHours()
        {
            int counter = 0;
            foreach (Subject sub in registeredSubjects)
            {
                counter = counter + sub.creditHours;
            }
            return counter;
        }
        public float calculateFee()
        {
            float fee = 0;
            if (enrolledDegree != null)
            {
                foreach (Subject sub in registeredSubjects)
                {
                    fee = fee + sub.subjectFee;
                }
            }
            return fee;
        }
        public bool registerSubject(Subject s)
        {
            int h = getCreditHours();
            if (enrolledDegree != null && enrolledDegree.doSubjectExist(s) && h + s.creditHours <= 9)
            {
                registeredSubjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
