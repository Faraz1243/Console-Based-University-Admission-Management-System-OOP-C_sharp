using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.DL;
using UAMS.UI;

namespace UAMS.BL
{
    internal class DegreeProgram
    {
        public string programTitle { get; set; }
        public string programDuration { get; set; }
        public int availableSeats { get; set; }
        public List<Subject> offeredSubjects= new List<Subject>();
        public List<Student> enrolledStudents = new List<Student>();
        public DegreeProgram(string programName, string programDuration, int availableSeats, List<Subject> offeredSubjects)
        {
            this.programTitle = programName;
            this.programDuration = programDuration;
            this.availableSeats = availableSeats;
            this.offeredSubjects = offeredSubjects;
        }
        public DegreeProgram(DegreeProgram degreeProgram)
        {
            this.programTitle = degreeProgram.programTitle;
            this.programDuration = degreeProgram.programDuration;
            this.availableSeats = degreeProgram.availableSeats;
            this.offeredSubjects = degreeProgram.offeredSubjects;
        }
        public float getMerit()
        {
            return enrolledStudents[enrolledStudents.Count - 1].merit();
        }
        public bool subjectValidation(string id)
        {
            foreach (Subject subject in offeredSubjects)
            {
                if (subject.subjectCode == id)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Subject> getSubjects()
        {
            return offeredSubjects;
        }
    }
}
