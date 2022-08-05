using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using UAMS.DL;

namespace UAMS.UI
{
    internal class StudentUI
    {
        public static Student addStudent()
        {
            MainUI.header();
            Console.WriteLine("Enter Student ID");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Student Age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student Ecat Marks");
            int ecat = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student FSc Marks");
            int fsc = int.Parse(Console.ReadLine());


            // for adding preferences
            List<string> preferences = new List<string>();
            while (true)
            {
                string pref = "";
                while (true)
                {
                    Console.WriteLine("Enter Student Preference ");
                    pref = Console.ReadLine();
                    if (StudentCRUD.preferenceValidation(pref, preferences))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Preference");
                        Console.WriteLine("Do You Want to Try Again? 'y' for Yes");
                        string answ = Console.ReadLine();
                        if (answ != "y" && answ != "Y")
                        { break; }
                    }
                }
                if (StudentCRUD.preferenceValidation(pref, preferences))
                {
                    preferences.Add(pref);
                    Console.WriteLine("Enter 'y' to add more preferences");
                    Console.WriteLine("Enter 'n' to stop adding preferences");
                    string ans = Console.ReadLine();
                    if (ans == "y")
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else { break; }
            }
            //create student type object
            Student student = new Student(id, name, age, ecat, fsc, preferences);
            return student;
        }
    }
}
