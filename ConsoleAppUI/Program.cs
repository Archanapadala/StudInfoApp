using StudBussinessLayer;
using StudDataLayer;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleAppUI
{
    class Program
    {
       
        static void Main(string[] args)
        {
            studBusiness obj = new studBusiness();
         
            Console.WriteLine("Student data is :");
            foreach(var stud in obj.Getstudents())
            {
                Console.WriteLine($"{stud.StudID} {stud.FirstName}  {stud.LastName}  {stud.Major} {stud.Credits} ");
            }
           

            Console.WriteLine("select database operation :");
            Console.WriteLine("1.Get student info by ID \n 2.Insert student info \n 3.Update student info \n4. delete student info ");
            int dbOperation = Convert.ToInt16(Console.ReadLine());
            switch(dbOperation)
            {
                case 1:

                    Console.WriteLine("Enter student id ");
                    int StudID = Convert.ToInt32(Console.ReadLine());
                    student stud = GetStudent(StudID);
                    Console.WriteLine($"{stud.StudID} {stud.FirstName}  {stud.LastName}  {stud.Major} {stud.Credits} ");
                    Console.Read();
                    break;
                case 2:
                    //insert
                    Console.WriteLine("Enter student details ");
                    student newstud = new student();
                    newstud.StudID = Convert.ToInt32(Console.ReadLine());
                    newstud.FirstName = Console.ReadLine();
                    newstud.LastName = Console.ReadLine();
                    newstud.Major = Console.ReadLine();
                    newstud.Credits = Convert.ToInt32(Console.ReadLine());
                    int recAffected = Insertstudent(newstud);
                    if (recAffected > 0)
                        Console.WriteLine("Record Inserted");
                    else
                        Console.WriteLine("Reconrd Not Inserted");


                    break;
                case 3:

                    //update
                    // Update
                    Console.WriteLine("Enter student ID to update: ");
                    int studIDToUpdate = Convert.ToInt32(Console.ReadLine());

                    // Get existing student details
                    student existingStudent = GetStudent(studIDToUpdate);

                    if (existingStudent != null)
                    {
                        Console.WriteLine("Enter updated student details:");
                        Console.WriteLine("Enter new First Name:");
                        string newFirstName = Console.ReadLine();
                        Console.WriteLine("Enter new Last Name:");
                        string newLastName = Console.ReadLine();
                        Console.WriteLine("Enter new Major:");
                        string newMajor = Console.ReadLine();
                        Console.WriteLine("Enter new Credits:");
                        int newCredits = Convert.ToInt32(Console.ReadLine());

                        // Update student details
                        existingStudent.FirstName = newFirstName;
                        existingStudent.LastName = newLastName;
                        existingStudent.Major = newMajor;
                        existingStudent.Credits = newCredits;

                        // Call method to update student in the database
                        int Affected = UpdateStudent(existingStudent);

                        if (Affected > 0)
                            Console.WriteLine("Record Updated");
                        else
                            Console.WriteLine("Record Not Updated");
                    }
                    else
                    {
                        Console.WriteLine("Student not found");
                    }

                    break;






           
                case 4:

                    //delete
                    break;

            }
            static student  GetStudent( int StudID)
            {
                studBusiness obj = new studBusiness();
                return obj.GetStudent(StudID);
            }
            static int Insertstudent(student stud)
            {
                studBusiness obj = new studBusiness();
                return obj.Insertstudent(stud);
            }
            static int UpdateStudent(student stud)
            {
                studBusiness obj = new studBusiness();
                return obj.Updatestudent(stud);
            }

        }
    }
}
