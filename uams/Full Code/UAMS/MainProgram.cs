using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using UAMS.DL;
using UAMS.UI;

namespace UAMS
{
    internal class MainProgram
    {
        static void Main(string[] args)
        {
            string option = "";
            while (true)
            {
                option = MainUI.userOption();
                if (option == "1")
                {  
                    Student student = StudentUI.addStudent();
                    StudentCRUD.students.Add(student);
                }
                else if (option == "2")
                { 
                    DegreeProgram program = DegreeUI.addDegreeProgram();
                    DegreeProgramCRUD.DegreePrograms.Add(program);
                }
                else if (option == "3")
                { 
                    DegreeProgramCRUD.generateMerit();
                    DegreeUI.printMerit();
                }
                else if (option == "4")
                {
                    DegreeUI.viewRegisteredStudents();
                }
                else if (option == "5") 
                { 
                    DegreeUI.studentsOfDegreePrograms();
                }
                else if (option == "6") 
                { 
                    int id = SubjectUI.getID4registerSubject();
                    string course = SubjectUI.getCourse4registerSubject(id);
                    Subject s = DegreeProgramCRUD.getSubject(course);
                    if(StudentCRUD.getStudent(id).registerSubject(s))//register subject and return true 
                    {                                                //if credit hours are less than 9
                        MainUI.popup("Subject Added Successfully! ");
                    }
                    else
                    {
                        MainUI.popup("Credit Hours Must not be Greater than 9! ");
                    }
                }
                else if (option == "7") 
                { 
                    StudentCRUD.calculateFee(); 
                }
                else if (option == "8") 
                {
                    DegreeProgramCRUD.saveSubjects();
                    DegreeProgramCRUD.saveDegrees();
                    StudentCRUD.saveStudents();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option");
                    Console.ReadKey();
                }
            }
        }
    }
}
