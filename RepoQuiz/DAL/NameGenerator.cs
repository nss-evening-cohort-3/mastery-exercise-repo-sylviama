using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoQuiz.Models;
using RepoQuiz.DAL;

namespace RepoQuiz.DAL
{
    public class NameGenerator
    {
        // This class should be used to generate random names and Majors for Students.
        // This is NOT your Repository
        // All methods should be Unit Tested :)
        public string NameGenerate()
        {
            StudentRepository repo = new StudentRepository();

            //Generate First Name
            //count total firstNames in database
            int firstNameCount = repo.FirstNamePickList().Count();
            Random rdn = new Random();
            //generate a ramdom number between 0 and count
            int firstNameNumber = rdn.Next(firstNameCount);
            //bring in the firstName list and get the ramdom generated one
            FirstNamePick[] arr = repo.FirstNamePickList().ToArray();
            string generatedFirstName= arr[firstNameNumber].FirstName;


            //Generate Last Name
            int lastNameCount = repo.LastNamePickList().Count();
            int lastNameNumber = rdn.Next(lastNameCount);
            LastNamePick[] arr2 = repo.LastNamePickList().ToArray();
            string generatedLastName = arr2[lastNameNumber].LastName;


            //Generate Major
            int majorCount = repo.MajorPickList().Count();
            int majorNumber = rdn.Next(majorCount);
            MajorPick[] arr3 = repo.MajorPickList().ToArray();
            string generatedmajor = arr3[majorNumber].MajorName;

            
            



            return generatedFirstName;
        }
        
    }
}