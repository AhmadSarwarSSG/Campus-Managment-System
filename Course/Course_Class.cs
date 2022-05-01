using System;

namespace Course
{
    public class Course_Class
    {
        int Id;
        string CourseName;
        int CreditHours;

        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }
        public string COURSENAME
        {
            get { return CourseName; }
            set { CourseName = value; }
        }
        public int CREDITHOURS
        {
            get { return CreditHours; }
            set { CreditHours = value; }
        }
    }
}
