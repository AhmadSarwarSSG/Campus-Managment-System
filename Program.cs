using System;
using Teacher;
using Student;
using Course;
using Admin;
namespace Assignment_02
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("~~~~~~~~~~~~~~WELCOME TO CMS~~~~~~~~~~~~~~");
                Console.WriteLine("Enter 1 to Login as Admin");
                Console.WriteLine("Enter 2 to Login as Student");
                Console.WriteLine("Enter 3 to Login as Teacher");
                Console.WriteLine("Enter 4 to Exit");
                string s = Console.ReadLine();
                if (s == string.Empty)
                {
                    Console.WriteLine("Nothing Selected");
                    continue;
                }
                else
                {
                    int i = int.Parse(s);
                    if(i==1)
                    {
                        Console.WriteLine("Enter Username");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter Password");
                        string password = Console.ReadLine();
                        
                        if(Admin_Class.AdminLogin(username, password))
                        {
                            Admin_Class.DisplayAdminMenu();
                            string s1 = Console.ReadLine();
                            if (s1 == string.Empty)
                            {
                                Console.WriteLine("Nothing Selected");
                                continue;
                            }
                            else
                            {
                                int i1 = int.Parse(s1);
                                if(i1==1)
                                {
                                    Admin_Class.Managestudents();
                                }
                                else if(i1==2)
                                {
                                    Admin_Class.ManageTeachers();
                                }
                                else if(i1==3)
                                {
                                    Admin_Class.ManageCources();
                                }
                                else if(i1==4)
                                {
                                    continue;
                                    }
                                else
                                {
                                    Console.WriteLine("Wrong Input");
                                }
                            }
                        }
                    }
                    else if(i==2)
                    {
                        Console.WriteLine("Enter Username");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter Password");
                        string password = Console.ReadLine();

                        if (Student_Class.StudentLogin(username, password))
                        {
                            Student_Class.DisplayStudentMenu();
                            string s1 = Console.ReadLine();
                            if (s1 == string.Empty)
                            {
                                Console.WriteLine("Nothing Selected");
                                continue;
                            }
                            else
                            {
                                int i1 = int.Parse(s1);
                                if (i1 == 1)
                                {
                                    Student_Class.PaySemesterDues(username);
                                }
                                else if (i1 == 2)
                                {
                                    Student_Class.ViewCourcesEnrolled(username);
                                }
                                else if (i1 == 3)
                                {
                                    Console.WriteLine("Enter the course Id for Assignment: ");
                                    string s2 = Console.ReadLine();
                                    Student_Class.ViewAssignments(username, int.Parse(s2));
                                }
                                else if(i1==4)
                                {
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine("Wrong Input");
                                }
                            }
                        }
                    }
                    else if(i==3)
                    {
                        Console.WriteLine("Enter Username");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter Password");
                        string password = Console.ReadLine();

                        if (Teacher_Class.TeacherLogin(username, password))
                        {
                            Teacher_Class.DisplayTeacherMenu();
                            string s1 = Console.ReadLine();
                            if (s1 == string.Empty)
                            {
                                Console.WriteLine("Nothing Selected");
                                continue;
                            }
                            else
                            {
                                int i1 = int.Parse(s1);
                                if (i1 == 1)
                                {
                                    Teacher_Class.MarkAttendacne(username);
                                }
                                else if (i1 == 2)
                                {
                                    Teacher_Class.PostAssignement(username);
                                }
                                else if (i1 == 3)
                                {
                                    Console.WriteLine("Enter the course Id for Assignment: ");
                                    string s2 = Console.ReadLine();
                                    Teacher_Class.ViewAssignedCources(username);
                                }
                                else if (i1 == 4)
                                {
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine("Wrong Input");
                                }
                            }
                        }
                    }
                    else if(i==4)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Input");
                    }
                }
            }
            
        }
    }
}
