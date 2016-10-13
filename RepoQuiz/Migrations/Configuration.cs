namespace RepoQuiz.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RepoQuiz.Models;
    using RepoQuiz.DAL;


    internal sealed class Configuration : DbMigrationsConfiguration<RepoQuiz.DAL.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RepoQuiz.DAL.StudentContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.firstNamePick.AddOrUpdate(
                f => f.FirstName,
                new FirstNamePick { FirstName = "Kate" },
                new FirstNamePick { FirstName = "Sylvia" },
                new FirstNamePick { FirstName = "Matt" },
                new FirstNamePick { FirstName = "Callan" },
                new FirstNamePick { FirstName = "Odi" },
                new FirstNamePick { FirstName = "Joe" },
                new FirstNamePick { FirstName = "Zoe" },
                new FirstNamePick { FirstName = "Cathy" },
                new FirstNamePick { FirstName = "Suzy" },
                new FirstNamePick { FirstName = "Alaric" },
                new FirstNamePick { FirstName = "Sabby" },
                new FirstNamePick { FirstName = "Bob" },
                new FirstNamePick { FirstName = "Da" },
                new FirstNamePick { FirstName = "Fei" },
                new FirstNamePick { FirstName = "Xiangwan" }
                );

            context.lastNamePick.AddOrUpdate(
                l=>l.LastName,
                new LastNamePick { LastName="Ma"},
                new LastNamePick { LastName = "Fei" },
                new LastNamePick { LastName = "Coury" },
                new LastNamePick { LastName = "Clinton" },
                new LastNamePick { LastName = "Trump" },
                new LastNamePick { LastName = "Pual" },
                new LastNamePick { LastName = "Lewis" },
                new LastNamePick { LastName = "Davis" },
                new LastNamePick { LastName = "McCann" },
                new LastNamePick { LastName = "McDonlad" },
                new LastNamePick { LastName = "King" },
                new LastNamePick { LastName = "Quinn" },
                new LastNamePick { LastName = "Potter" },
                new LastNamePick { LastName = "Green" },
                new LastNamePick { LastName = "Galler" }
                );

            context.majorPick.AddOrUpdate(
                m=>m.MajorName,
                new MajorPick { MajorName="Mechanical Engineering"},
                new MajorPick { MajorName = "Industrial Engineering" },
                new MajorPick { MajorName = "Music" },
                new MajorPick { MajorName = "Accounting" },
                new MajorPick { MajorName = "Finance" },
                new MajorPick { MajorName = "Economics" },
                new MajorPick { MajorName = "Civil Engineering" },
                new MajorPick { MajorName = "Computer Science" },
                new MajorPick { MajorName = "Information Technology" }
                );

            context.Students.AddOrUpdate(
                s=> new { s.FirstName, s.LastName},
                new Student { FirstName="Lee", LastName="Nernoll", Major="Music"},
                new Student { FirstName = "Heather", LastName = "Rasberry", Major = "Music" },
                new Student { FirstName = "Jianfan", LastName = "Chen", Major = "Civil Engineering" }
                );

        }
    }
}
