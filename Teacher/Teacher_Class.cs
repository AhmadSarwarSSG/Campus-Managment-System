using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
namespace Teacher
{
    public class Teacher_Class
    {
        int Id;
        string Name;
        int Salary;
        int Experience;
        int NoOfCources;
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
        public int SALARY
        {
            get { return Salary; }
            set { Salary = value; }
        }
        public int EXPERINCE
        {
            get { return Experience; }
            set { Experience = value; }
        }
        public int COURCES
        {
            get { return NoOfCources; }
            set { NoOfCources = value; }
        }

        public static bool TeacherLogin(string username, string password)
        {
            string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = $"Select * from Login Where Name=@U AND Password=@P AND Type='Teacher'";
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
        public static void DisplayTeacherMenu()
        {
            Console.WriteLine("~~~~~~~~~~~~~~Teacher Menu~~~~~~~~~~~~~~");
            Console.WriteLine("Enter 1 to Mark Attandacne");
            Console.WriteLine("Enter 2 to Post Assignment");
            Console.WriteLine("Enter 3 to View Assigned Cources");
            Console.WriteLine("Enter 4 to Exit");
        }
        public static void MarkAttendacne(string username)
        {
            string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query1 = "select Id from Teacher Where UserN=@U";
            SqlParameter p1_1 = new SqlParameter("U", username);
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.Add(p1_1);
            SqlDataReader sdr = cmd1.ExecuteReader();
            sdr.Read();
            int id = int.Parse(sdr[0].ToString());
            con.Close();
            con.Open();
            ViewAssignedCources(username);
            Console.WriteLine("Enter Course ID: ");
            int c = int.Parse(Console.ReadLine());
            string query2 = "select Student_Id from Student_Courses Where Course_Id=@I";
            SqlParameter p1_2 = new SqlParameter("I", c);
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.Add(p1_2);
            SqlDataReader sdr1 = cmd2.ExecuteReader();
            List<int> L = new List<int>();
            while(sdr1.Read())
            {
                L.Add(int.Parse(sdr1[0].ToString()));
            }
            con.Close();
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();
            foreach(int i in L)
            {
                string query3 = "insert into AttendacneInformation(Cources_Id, Student_Id, Teacher_Id, Attendacne, Date) values(@A, @B, @C, @D, @E)";
                SqlParameter p2_1 = new SqlParameter("A", c);
                SqlParameter p2_2 = new SqlParameter("B", i);
                SqlParameter p2_3 = new SqlParameter("C", id);
                Console.WriteLine($"Enter Attandacne for Student with ID#{i}: ");
                string s = Console.ReadLine();
                SqlParameter p2_4 = new SqlParameter("D", s);
                SqlParameter p2_5 = new SqlParameter("E", $"{DateTime.Today.Day}-{DateTime.Today.Month}-{DateTime.Today.Year}");
                SqlCommand cmd3 = new SqlCommand(query3, con1);
                cmd3.Parameters.Add(p2_1);
                cmd3.Parameters.Add(p2_2);
                cmd3.Parameters.Add(p2_3);
                cmd3.Parameters.Add(p2_4);
                cmd3.Parameters.Add(p2_5);
                cmd3.ExecuteNonQuery();
            }
            con1.Close();
        }
        public static void PostAssignement(string username)
        {
            string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query1 = "select Id from Teacher Where UserN=@U";
            SqlParameter p1_1 = new SqlParameter("U", username);
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.Add(p1_1);
            SqlDataReader sdr = cmd1.ExecuteReader();
            sdr.Read();
            int id = int.Parse(sdr[0].ToString());
            ViewAssignedCources(username);
            con.Close();
            con.Open();
            Console.WriteLine("Enter Course Id: ");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Assignment Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Assignment Description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter Assignment Deadline: ");
            string date = Console.ReadLine();
            string query3 = "insert into AssignmentInformation(Course_Id, Teacher_Id, Title, Description, Deadline) values(@C, @T, @X, @D, @Y)";
            SqlParameter P1 = new SqlParameter("C", c);
            SqlParameter P2 = new SqlParameter("T", id);
            SqlParameter P3 = new SqlParameter("X", title);
            SqlParameter P4 = new SqlParameter("D", description);
            SqlParameter P5 = new SqlParameter("Y", date);
            SqlCommand cmd3 = new SqlCommand(query3, con);
            cmd3.Parameters.Add(P1);
            cmd3.Parameters.Add(P2);
            cmd3.Parameters.Add(P3);
            cmd3.Parameters.Add(P4);
            cmd3.Parameters.Add(P5);
            int i = cmd3.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("~~~~~Assignment Alloted~~~~~");
        }
        public static void ViewAssignedCources(string username)
        {
            string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query1 = "select Id from Teacher Where UserN=@U";
            SqlParameter p1_1 = new SqlParameter("U", username);
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.Add(p1_1);
            SqlDataReader sdr = cmd1.ExecuteReader();
            sdr.Read();
            int id = int.Parse(sdr[0].ToString());
            con.Close();
            con.Open();
            string query = "select Course.Id, Course.CourseName from Teacher_Cources Inner Join Course on Teacher_Cources.Course_Id=Course.Id Where Teacher_Cources.Teacher_Id=@U";
            SqlParameter p1 = new SqlParameter("U", id);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);
            SqlDataReader sdr1 = cmd.ExecuteReader();
            Console.WriteLine("Courses");
            int count = 0;
            while (sdr1.Read())
            {
                Console.WriteLine(string.Format("{0}-{1,30}", sdr1[0], sdr1[1]));
                count++;
            }
            con.Close();
        }
    }
}
