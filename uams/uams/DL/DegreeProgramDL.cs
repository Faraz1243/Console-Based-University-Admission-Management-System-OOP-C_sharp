using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using uams.UI;
using System.IO;

namespace uams.DL
{
    class DegreeProgramDL
    {
        public static List<DegreeProgram> degreePrograms = new List<DegreeProgram>();
        public static void addToDegrees(DegreeProgram d)
        {
            degreePrograms.Add(d);
        }

        public static DegreeProgram isDegreeExists(string degreeName)
        {
            foreach (DegreeProgram deg in degreePrograms)
            {
                if (deg.degreeName == degreeName)
                {
                    return deg;
                }
            }
            return null;
        }

        public static void save(string path, DegreeProgram d)
        {
            StreamWriter sw = new StreamWriter(path, true);
            string SubjectNames = "";
            for(int x = 0; x < d.subjects.Count - 1; x++)
            {
                SubjectNames = SubjectNames + d.subjects[x].type + ";";
            }
            SubjectNames = SubjectNames + d.subjects[d.subjects.Count - 1].type;
            sw.WriteLine(d.degreeName + "," + d.duration + "," + d.availableSeats + "," + SubjectNames);
            sw.Flush();
            sw.Close();
        }
        public static void load()
        {
            StreamReader sr = new StreamReader("degrees.txt");
            string record;
            if (File.Exists("degrees.txt"))
            {
                while ((record = sr.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string degreeName = splittedRecord[0];
                    float degreeDuration = float.Parse(splittedRecord[1]);
                    int seats = int.Parse(splittedRecord[2]);
                    string[] splittedRecordForSubject = splittedRecord[3].Split(';');
                    DegreeProgram d = new DegreeProgram(degreeName, degreeDuration, seats);
                    for (int x = 0; x < splittedRecordForSubject.Length; x++)
                    {
                        Subject s = SubjectDL.doSubjectExists(splittedRecordForSubject[x]);
                        if (s != null)
                        {
                            d.addSubject(s);
                        }
                    }
                    addToDegrees(d);
                }
                sr.Close();
            }
        }
    }
}
