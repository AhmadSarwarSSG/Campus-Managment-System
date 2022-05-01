using System;
using Microsoft.Data.SqlClient;
namespace Admin
{
    public class Admin_Class
    {
        public static bool AdminLogin(string username, string password)
        {
            string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = $"Select * from Login Where Name=@U AND Password=@P AND Type='Admin'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlParameter p1 = new SqlParameter("U", username);
            SqlParameter p2 = new SqlParameter("P", password);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            SqlDataReader dr = cmd.ExecuteReader();
            bool check=dr.HasRows;
            con.Close();
            return check;
        }
        public static void DisplayAdminMenu()
        {
            Console.WriteLine("~~~~~~~~~~~~~~Admin Menu~~~~~~~~~~~~~~");
            Console.WriteLine("Enter 1 to Manage Student");
            Console.WriteLine("Enter 2 to Manage teacher");
            Console.WriteLine("Enter 3 to Manage Cources");
            Console.WriteLine("Enter 4 to Exit");
        }
        public static void Managestudents()
        {
            Console.WriteLine("1- Add Student");
            Console.WriteLine("2- Update Student");
            Console.WriteLine("3- Delete Student");
            Console.WriteLine("4- View All Students");
            Console.WriteLine("5- View Outstanding Dues");
            Console.WriteLine("6- Assign Cources");
            Console.WriteLine("7- Exit");
            int i = int.Parse(Console.ReadLine());
            if(i==1)
            {
                Console.WriteLine("Entrt Student Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Entrt Student Roll NO: ");
                string roll = Console.ReadLine();
                Console.WriteLine("Entrt Student Batch: ");
                string batch = Console.ReadLine();
                Console.WriteLine("Entrt Student Dues: ");
                int due = int.Parse(Console.ReadLine());
                Console.WriteLine("Entrt Student Current Semester: ");
                int sem = int.Parse(Console.ReadLine());
                Console.WriteLine("Entrt Student Username: ");
                string UN = Console.ReadLine();
                string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";          
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = $"insert into Student(Name, RollNo, Batch, SemesterDues, CurrentSemester, UserN) values(@N, @R, @B, @S, @C, @U)";
                string query1 = $"insert into Login(Name, Password, Type) values(@N, @P, @T)";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlParameter p1 = new SqlParameter("N", name);
                SqlParameter p2 = new SqlParameter("R", roll);
                SqlParameter p3 = new SqlParameter("B", batch);
                SqlParameter p4 = new SqlParameter("S", due);
                SqlParameter p5 = new SqlParameter("C", sem);
                SqlParameter p6 = new SqlParameter("U", UN);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlParameter p1_1 = new SqlParameter("N", UN);
                SqlParameter p1_2 = new SqlParameter("P", "1234");
                SqlParameter p1_3 = new SqlParameter("T", "Student");
                cmd1.Parameters.Add(p1_1);
                cmd1.Parameters.Add(p1_2);
                cmd1.Parameters.Add(p1_3);
                cmd1.ExecuteNonQuery();
                con.Close();
            }
            else if (i == 2)
            {
                Console.WriteLine("Entrt Student Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Entrt Student Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Entrt Student Roll NO: ");
                string roll = Console.ReadLine();
                Console.WriteLine("Entrt Student Batch: ");
                string batch = Console.ReadLine();
                Console.WriteLine("Entrt Student Dues: ");
                int due = int.Parse(Console.ReadLine());
                Console.WriteLine("Entrt Student Current Semester: ");
                int sem = int.Parse(Console.ReadLine());
                Console.WriteLine("Entrt Student Username: ");
                string UN = Console.ReadLine();
                string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = $"update Student set Name=@N, RollNo=@R, Batch=@B, SemesterDues=@S, CurrentSemester=@C, UserN=@U Where Id=@I";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlParameter p0 = new SqlParameter("I", id);
                SqlParameter p1 = new SqlParameter("N", name);
                SqlParameter p2 = new SqlParameter("R", roll);
                SqlParameter p3 = new SqlParameter("B", batch);
                SqlParameter p4 = new SqlParameter("S", due);
                SqlParameter p5 = new SqlParameter("C", sem);
                SqlParameter p6 = new SqlParameter("U", UN);
                cmd.Parameters.Add(p0);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else if (i == 3)
            {
                Console.WriteLine("Entrt Student Id: ");
                int id = int.Parse(Console.ReadLine());
                string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = $"delete from Student where Id=@I";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlParameter p0 = new SqlParameter("I", id);
                cmd.Parameters.Add(p0);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else if (i == 4)
            {
                string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = "Select * from Student";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine(string.Format("{0,-10}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}", "ID", "Name", "Roll NO","Batch", "Dues", "Semester", "UserName"));
                
                while (dr.Read())
                {
                    Console.WriteLine(string.Format("{0,-10}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}", dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString()));
                }
                con.Close();
            }
            else if (i == 5)
            {
                Console.WriteLine("Entrt Student Id: ");
                int id = int.Parse(Console.ReadLine());
                string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = $"select Name, RollNo, SemesterDues from Student Where Id=@I";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlParameter p0 = new SqlParameter("I", id);
                cmd.Parameters.Add(p0);
                SqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine(string.Format("{0,-30}{1,-20}{2,-10}", "Name", "Roll NO", "Semester Dues"));
                while (dr.Read())
                {
                    Console.WriteLine(string.Format("{0,-30}{1,-20}{2,-10}", dr[0], dr[1], dr[2]));
                }
                con.Close();
            }
            else if(i==6)
            {
                Console.WriteLine("Entrt Student Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Entrt Course Id: ");
                int c_id = int.Parse(Console.ReadLine());
                string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = $"insert into Student_Courses(Course_Id, Student_Id) values(@I, @C)";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlParameter p0 = new SqlParameter("I", id);
                SqlParameter p1 = new SqlParameter("C", c_id);
                cmd.Parameters.Add(p0);
                cmd.Parameters.Add(p1);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else if(i == 7)
            {
                return;
            }
            else
            {
                Console.WriteLine("Wrong Inputs");
            }
        }
        public static void ManageTeachers()
        {
            Console.WriteLine("1- Add Teacher");
            Console.WriteLine("2- Update Teacher");
            Console.WriteLine("3- Delete Teacher");
            Console.WriteLine("4- View All Teachers");
            Console.WriteLine("5- Assign Cources");
            Console.WriteLine("6- Exit");
            int i = int.Parse(Console.ReadLine());
            if (i == 1)
            {
                Console.WriteLine("Entrt Teacher Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Entrt Teacher Salary: ");
                int sal = int.Parse(Console.ReadLine());
                Console.WriteLine("Entrt Teacher Experience: ");
                int exp = int.Parse(Console.ReadLine());
                Console.WriteLine("Entrt No Of Cources: ");
                string NoC = Console.ReadLine();
                Console.WriteLine("Entrt Username: ");
                string UN = Console.ReadLine();
                string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = $"insert into Teacher(Name, Salary, Experince, NoOfCources, UserN) values(@N, @R, @B, @S, @U)";
                string query1 = $"insert into Login(Name, Password, Type) values(@N, @P, @T)";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlParameter p1 = new SqlParameter("N", name);
                SqlParameter p2 = new SqlParameter("R", sal);
                SqlParameter p3 = new SqlParameter("B", exp);
                SqlParameter p4 = new SqlParameter("S", NoC);
                SqlParameter p5 = new SqlParameter("U", UN);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlParameter p1_1 = new SqlParameter("N", UN);
                SqlParameter p1_2 = new SqlParameter("P", "1234");
                SqlParameter p1_3 = new SqlParameter("T", "Teacher");
                cmd1.Parameters.Add(p1_1);
                cmd1.Parameters.Add(p1_2);
                cmd1.Parameters.Add(p1_3);
                cmd1.ExecuteNonQuery();
                con.Close();
            }
            else if (i == 2)
            {
                Console.WriteLine("Entrt Teacher ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Entrt Teacher Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Entrt Teacher Salary: ");
                int sal = int.Parse(Console.ReadLine());
                Console.WriteLine("Entrt Teacher Experience: ");
                int exp = int.Parse(Console.ReadLine());
                Console.WriteLine("Entrt No Of Cources: ");
                string NoC = Console.ReadLine();
                Console.WriteLine("Entrt Username: ");
                string UN = Console.ReadLine();
                string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = $"update Teacher Set Name=@N, Salary=@R, Experince=@B, NoOfCources=@S, UserN=@C Where Id=@I";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlParameter p0 = new SqlParameter("I", id);
                SqlParameter p1 = new SqlParameter("N", name);
                SqlParameter p2 = new SqlParameter("R", sal);
                SqlParameter p3 = new SqlParameter("B", exp);
                SqlParameter p4 = new SqlParameter("S", NoC);
                SqlParameter p5 = new SqlParameter("C", UN);
                cmd.Parameters.Add(p0);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else if (i == 3)
            {
                Console.WriteLine("Entrt Teacher Id: ");
                int id = int.Parse(Console.ReadLine());
                string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = $"delete from Teacher where Id=@I";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlParameter p0 = new SqlParameter("I", id);
                cmd.Parameters.Add(p0);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else if (i == 4)
            {
                string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = "Select * from Teacher";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine(string.Format("{0,-10}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}", "ID", "Name", "Salary", "Experinence", "NoOfCources", "User Name"));
                while (dr.Read())
                {
                    Console.WriteLine(string.Format("{0,-10}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]));
                }
                con.Close();
            }
            else if (i == 5)
            {
                Console.WriteLine("Entrt Teacher Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Entrt Course Id: ");
                int c_id = int.Parse(Console.ReadLine());
                string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = $"insert into Teacher_Cources(Course_Id, Teacher_Id) values(@I, @C)";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlParameter p0 = new SqlParameter("I", id);
                SqlParameter p1 = new SqlParameter("C", c_id);
                cmd.Parameters.Add(p0);
                cmd.Parameters.Add(p1);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else if(i == 6)
            {
                return;
            }
            else
            {
                Console.WriteLine("Wrong Input");
            }
        }
        public static void ManageCources()
        {
            Console.WriteLine("1- Add Course");
            Console.WriteLine("2- Update Course");
            Console.WriteLine("3- Delete Course");
            Console.WriteLine("4- View All Course");
            Console.WriteLine("6- Exit");
            int i = int.Parse(Console.ReadLine());
            if (i == 1)
            {
                Console.WriteLine("Entrt Cource Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Entrt Credit Hours: ");
                int CR = int.Parse(Console.ReadLine());
                string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = $"insert into Course(CourseName, CreditHous) values(@N, @R)";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlParameter p1 = new SqlParameter("N", name);
                SqlParameter p2 = new SqlParameter("R", CR);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            if (i == 2)
            {
                Console.WriteLine("Entrt Cource ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Entrt Cource Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Entrt Credit Hours: ");
                int CR = int.Parse(Console.ReadLine());
                string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = $"update Course Set CourseName=@N, CreditHous=@R Where Id=@I";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlParameter p0 = new SqlParameter("I", id);
                SqlParameter p1 = new SqlParameter("N", name);
                SqlParameter p2 = new SqlParameter("R", CR);
                cmd.Parameters.Add(p0);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            if (i == 3)
            {
                Console.WriteLine("Entrt Student Id: ");
                int id = int.Parse(Console.ReadLine());
                string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = $"delete from Course where Id=@I";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlParameter p0 = new SqlParameter("I", id);
                cmd.Parameters.Add(p0);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            if (i == 4)
            {
                string conString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string query = "Select * from Course";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine(string.Format("{0,-10}{1,-15}{2,-15}", "ID", "Name", "CreditHours"));

                while (dr.Read())
                {
                    Console.WriteLine(string.Format("{0,-10}{1,-15}{2,-15}", dr[0], dr[1], dr[2]));
                }
                con.Close();
            }
        }
    }
}
