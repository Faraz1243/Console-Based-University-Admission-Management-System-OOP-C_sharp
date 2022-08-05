using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uams.BL
{
    class DegreeProgram
    {
        public string degreeName;
        public float duration;
        public List<Subject> subjects;
        public int availableSeats;
        public DegreeProgram(string degreeName, float duration, int availableSeats)
        {
            this.degreeName = degreeName;
            this.duration = duration;
            this.availableSeats = availableSeats;
            subjects = new List<Subject>();
        }
        
        public bool doSubjectExist(Subject s)
        {
            foreach (Subject sub in subjects)
            {
                if (sub.code == s.code)
                {
                    return true;
                }
            }
            return false;
        }
        public bool addSubject(Subject s)
        {
            int hours = calculateHours();
            if(hours + s.creditHours <= 20)
            {
                subjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int calculateHours()
        {
            int count = 0;
            for (int x = 0; x < subjects.Count; x++)
            {
                count = count + subjects[x].creditHours;
            }
            return count;
        }
    }
}
