using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
namespace Student
{
    public class Student_Class
    {
        int Id;
        string Name;
        string RollNo;
        string Batch;
        int SemesterDues;
        int CurrentSemester;
        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }
        public string NAME
        {
            get { return Name; }
            set { Name = value; }
        }
        public string ROLLNO
        {
            get { return RollNo; }
            set { RollNo = value; }
        }
        public string BATCH
        {
            get { return Batch; }
            set { Batch = value; }
        }
        public int SEMESTERDUES
        {
            get { return SemesterDues; }
            set { SemesterDues = value; }
        }
        public int CURRENTSEMESTER
        {
            get { return CurrentSemester; }
            set { CurrentSemester = value; }
        }

        public static bool StudentLogin(string username, string password)
        {
            string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = $"Select * from Login Where Name=@U AND Password=@P AND Type='Student'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlParameter p1 = new SqlParameter("U", username);
            SqlParameter p2 = new SqlParameter("P", password);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            SqlDataReader dr = cmd.ExecuteReader();
            bool check = dr.HasRows;
            con.Close();
            return check;
        }
        public static void DisplayStudentMenu()
        {
            Console.WriteLine("~~~~~~~~~~~~~~WELCOME TO CMS~~~~~~~~~~~~~~");
            Console.WriteLine("Enter 1 to pay semester dues");
            Console.WriteLine("Enter 2 to view enrolled courses");
            Console.WriteLine("Enter 3 to view attandacne");
            Console.WriteLine("Enter 4 to Exit");
        }
        public static void PaySemesterDues(string username)
        {
            int payable = 0;
            int dues=0;
            string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query1 = "select SemesterDues from Student Where UserN=@U";
            SqlParameter p1_1 = new SqlParameter("U", username);
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.Add(p1_1);
            SqlDataReader sdr = cmd1.ExecuteReader();
            sdr.Read();
            dues = int.Parse(sdr[0].ToString());
            con.Close();
            if (dues!=0)
            {
                while(true)
                {
                    Console.WriteLine("Enter dues you want to pay:");
                    payable=int.Parse(Console.ReadLine());
                    if(dues-payable < 0)
                    {
                        Console.WriteLine("You are paying more than required Enter amount again...!");
                    }
                    else
                    {
                        break;
                    }
                }
                con.Open();
                string query = "Update Student set SemesterDues=@S-@D where UserN=@U";
                SqlParameter p1 = new SqlParameter("U", username);
                SqlParameter p2 = new SqlParameter("S", dues);
                SqlParameter p3 = new SqlParameter("D", payable);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Dues Paid Successfully...!");
            }
            else
            {
                Console.WriteLine("You have no pending dues");
            }
        }
        public static void ViewCourcesEnrolled(string username)
        {
            string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query1 = "select Id from Student Where UserN=@U";
            SqlParameter p1_1 = new SqlParameter("U", username);
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.Add(p1_1);
            SqlDataReader sdr = cmd1.ExecuteReader();
            sdr.Read();
            int id = int.Parse(sdr[0].ToString());
            con.Close();
            con.Open();
            string query = "select Course.CourseName from Student_Courses Inner Join Course on Student_Courses.Course_Id=Course.Id Where Student_Courses.Student_Id=@U";
            SqlParameter p1 = new SqlParameter("U", id);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);
            SqlDataReader sdr1 = cmd.ExecuteReader();
            Console.WriteLine("Courses\n\n");
            int count = 0;
            while(sdr1.Read())
            {
                Console.WriteLine(string.Format("{0}-{1,30}", count, sdr1[0]));
                count++;
            }
            con.Close();
        }
        public static void ViewAssignments(string username, int course_ID)
        {
            string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query1 = "select Id from Student Where UserN=@U";
            SqlParameter p1_1 = new SqlParameter("U", username);
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.Add(p1_1);
            SqlDataReader sdr = cmd1.ExecuteReader();
            sdr.Read();
            int id = int.Parse(sdr[0].ToString());
            con.Close();
            con.Open();
            string query2 = "select * from Student_Courses Where Course_Id=@C AND Student_Id=@S";
            SqlParameter p1_2 = new SqlParameter("C", course_ID);
            SqlParameter p2_2 = new SqlParameter("S", id);
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.Add(p1_2);
            cmd2.Parameters.Add(p2_2);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            if(sdr2.HasRows)
            {
                con.Close();
                con.Open();
                string query3 = "select * from AssignmentInformation Where Course_Id=@C";
                SqlParameter p1_3 = new SqlParameter("C", course_ID);
                SqlCommand cmd3 = new SqlCommand(query3, con);
                cmd3.Parameters.Add(p1_3);
                SqlDataReader sdr3 = cmd3.ExecuteReader();
                Console.WriteLine(String.Format("{0,-20}{1,-20}{2,-30}{3,-20}", "Course_ID", "Title", "Description", "Deadline"));
                while(sdr3.Read())
                {
                    Console.WriteLine(string.Format("{0,-20}{1,-20}{2,-30}{3,-20}",sdr3[0], sdr3[2], sdr3[3], sdr3[4]));
                }
                con.Close();
            }
            else
            {
                con.Close();
                Console.WriteLine("Sorry You are not reigstered in this course");
            }
        }
    }
}
