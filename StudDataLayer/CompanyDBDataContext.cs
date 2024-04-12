using System;


using System.Data.SqlClient;



namespace StudDataLayer
{
    public  class CompanyDBDataContext
    {
        SqlConnection con = null;
        public List<student> Getstudents()
        {
            con = new SqlConnection("server = . ; database = CompanyDB ; integrated security = true;");
            List<student> students = new List<student>();
            SqlCommand cmd = new SqlCommand("select * from Student", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    student stud = new student();
                    stud.StudID =Convert.ToInt32( dr["StudID"]);
                    stud.LastName = Convert.ToString(dr["LastName"]);
                    stud.FirstName = Convert.ToString(dr["firstName"]);
                    stud.Major = Convert.ToString(dr["Major"]);
                    stud.Credits = Convert.ToInt32(dr["Credits"]);
                    students.Add(stud);

                }
               
            }
            con.Close();  
            return students;



        }
        public student GetStudent(int StudID)
        {
            con = new SqlConnection("server = .; database = CompanyDB ; integrated security = true;");
            student stud = new student();
            SqlCommand cmd = new SqlCommand("select * from Student where StudID = "+StudID , con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows )
            {
                if (dr.Read())
                {
                    stud.StudID = Convert.ToInt32(dr["StudID"]);
                    stud.LastName = Convert.ToString(dr["LastName"]);
                    stud.FirstName = Convert.ToString(dr["firstName"]);
                    stud.Major = Convert.ToString(dr["Major"]);
                    stud.Credits = Convert.ToInt32(dr["Credits"]);
                }
            }
            con.Close();
            return stud;
        }
        public int InsertStudent(student Stud)
        {
            con = new SqlConnection("server = .; database = CompanyDB ; integrated security = true;");
            SqlCommand cmd = new SqlCommand($"Insert into Student values({Stud.StudID}, '{Stud.LastName}', '{Stud.FirstName}' ,' {Stud.Major}' , {Stud.Credits} )", con);
            con.Open();
            int rec = cmd.ExecuteNonQuery();
            con.Close();
            return rec;

        }
        public int Updatestudent(student Stud)
        {
            con = new SqlConnection("server = .; database = CompanyDB ; integrated security = true;");
            SqlCommand cmd = new SqlCommand($"Update Student set StudID={Stud.StudID}, FirstName='{Stud.LastName}', LastName='{Stud.FirstName}' ,Major =' {Stud.Major}' , Credits ={Stud.Credits}  where StudID= {Stud.StudID}", con);
            con.Open();
            int rex = cmd.ExecuteNonQuery();
            con.Close();
            return rex;

        }

          

    }
}