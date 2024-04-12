using StudDataLayer;

namespace StudBussinessLayer
{
    public class studBusiness
    {
        CompanyDBDataContext context = new CompanyDBDataContext();
        public List<student> Getstudents()
        {
            return context.Getstudents();
        }
        public student GetStudent(int StudID)
        {
            return context.GetStudent(StudID);

        }
        public int Insertstudent(student stud)
        {
            return context.InsertStudent(stud);
        }
        public int Updatestudent(student stud)
        {
            return context.Updatestudent(stud);
        }


    }
}
