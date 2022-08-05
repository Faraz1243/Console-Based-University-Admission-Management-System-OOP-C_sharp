using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.DL;
using UAMS.UI;

namespace UAMS.BL
{
    internal class Student
    {
        public int studentId;
        public string name { get; set; }
        public int age { get; set; }
        public int ecat { get; set; }
        public int fsc { get; set; }

        public List<string> preferences = new List<string>();
        public List<Subject> registeredSubjects = new List<Subject>();
        public Student(int studentId, string name, int age, int ecat, int fsc, List<string> preferences)
        {
            this.studentId = studentId;
            this.name = name;
            this.age = age;
            this.ecat = ecat;
            this.fsc = fsc;
            this.preferences = preferences;
        }
        public float merit()
        {
            float merit = (this.ecat / 400) * 40 + (this.fsc / 1100) * 60;
            return merit;
        }
        public int getFees()
        {
            int fee = 0;
            foreach(Subject s in registeredSubjects)
            {
                fee += s.subjectFee;
            }
            return fee;
        }
        public int getCreditHours()
        {
            int creditHours = 0;
            foreach (Subject s in registeredSubjects)
            {
                creditHours += s.subjectCreditHours;
            }
            return creditHours;
        }
        public bool registerSubject(Subject subject)
        {
            if(getCreditHours()+subject.subjectCreditHours<=9)
            {
                registeredSubjects.Add(subject);
                return true;
            }
            return false;
        }
    }
}
 