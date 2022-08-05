using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using uams.DL;
using uams.UI;

namespace uams
{
    public class Program
    {
        static void Main(string[] args)
        {
            SubjectDL.load();
            DegreeProgramDL.load();
            StudentDL.load();
            
            int option = 0;
            while (option != 8) 
            {
                option = ConsoleUI.mainMenu();
                if (option == 1)
                {
                    if (DegreeProgramDL.degreePrograms.Count > 0)
                    {
                        Student s = StudentUI.inputForStudent();
                        StudentDL.addStudent(s);
                        StudentDL.save("students.txt", s);
                    }
                    else { ConsoleUI.noDegreePrograms(); }
                }
                else if (option == 2)
                {
                    DegreeProgram degree = DegreeProgramUI.inputDegree();
                    DegreeProgramDL.addToDegrees(degree);
                    DegreeProgramDL.save("degrees.txt", degree);
                }
                else if (option == 3)
                {
                    List<Student> sortedStudentList = new List<Student>();
                    sortedStudentList = StudentDL.sortStudentsByMerit();
                    StudentDL.giveAdmission(sortedStudentList);
                    StudentUI.printAdmittedStudents();
                }
                else if (option == 4)
                {
                    StudentUI.registeredStudents();
                }
                else if (option == 5)
                {
                    string degName = DegreeProgramUI.inputDegreeName();
                    StudentUI.studentOfProgram(degName);
                }
                else if (option == 6)
                {
                    string name = StudentUI.getName();
                    Student s = StudentDL.StudentPresent(name);
                    if (s != null)
                    {
                        SubjectUI.viewSubjects(s);
                        SubjectUI.registerSubjects(s);
                    }
                 
                }
                else if (option == 7)
                {
                    StudentUI.calculateFee();
                }
                else if (option ==8)
                {
                    break;
                }
            }
        }
    }
}
