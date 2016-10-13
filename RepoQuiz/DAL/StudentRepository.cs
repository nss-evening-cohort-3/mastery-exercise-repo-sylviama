using RepoQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepoQuiz.DAL
{
    public class StudentRepository
    {
        StudentContext Context { get; set; }

        public StudentRepository()
        {
            Context = new StudentContext();
        }

        public StudentRepository(StudentContext studentContext)
        {
            Context = studentContext;
        }

        public List<FirstNamePick> FirstNamePickList()
        {
            return Context.firstNamePick.ToList();
        }

        public List<LastNamePick> LastNamePickList()
        {
            return Context.lastNamePick.ToList();
        }

        public List<MajorPick> MajorPickList()
        {
            return Context.majorPick.ToList();
        }

        public List<Student> GetAllStudents()
        {
            return Context.Students.ToList();
        }

    }
}