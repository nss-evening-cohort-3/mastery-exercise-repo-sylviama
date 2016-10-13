using RepoQuiz.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace RepoQuiz.DAL
{
    public class StudentContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<FirstNamePick> firstNamePick { get; set; }
        public virtual DbSet<LastNamePick> lastNamePick { get; set; }
        public virtual DbSet<MajorPick> majorPick { get; set; }
    }
}