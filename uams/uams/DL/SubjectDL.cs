using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using System.IO;

namespace uams.DL
{
    class SubjectDL
    {
        public static List<Subject> subjectList = new List<Subject>();

        public static void addSubjectToList(Subject s)
        {
            subjectList.Add(s);
        }
        public static Subject doSubjectExists(string type)
        {
            foreach (Subject s in subjectList)
            {
                if (s.type == type)
                {
                    return s;
                }
            }
            return null;
        }
        public static void save(string path, Subject s)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(s.code + "," + s.type + "," + s.creditHours + "," + s.subjectFee);
            file.Flush();
            file.Close();
        }
        public static void load()
        {
            StreamReader f = new StreamReader("subjects.txt");
            string record;
            if (File.Exists("subjects.txt"))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] arr = record.Split(',');
                    string code = arr[0];
                    string type = arr[1];
                    int creditHours = int.Parse(arr[2]);
                    int subjectFees = int.Parse(arr[3]);
                    Subject s = new Subject(code, type, creditHours, subjectFees);
                    addSubjectToList(s);
                }
                f.Close();
            }
        }
    }
}
