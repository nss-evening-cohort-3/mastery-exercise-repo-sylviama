using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data.Entity;
using RepoQuiz.Models;
using RepoQuiz.DAL;

namespace RepoQuiz.Tests.DAL
{
    [TestClass]
    public class StudentRepositoryTests
    {
        Mock<StudentContext> mock_context { get; set; }

        Mock<DbSet<FirstNamePick>> firstName_mock_dbset { get; set; }
        Mock<DbSet<LastNamePick>> lastName_mock_dbset { get; set; }
        Mock<DbSet<MajorPick>> major_mock_dbset { get; set; }
        Mock<DbSet<Student>> student_mock_dbset { get; set; }

        List<FirstNamePick> firstName_datastore { get; set; }
        List<LastNamePick> lastName_datastore { get; set; }
        List<MajorPick> major_datastore { get; set; }
        List<Student> student_datastore { get; set; }

        StudentRepository repo { get; set; }



        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<StudentContext>();

            firstName_mock_dbset = new Mock<DbSet<FirstNamePick>>();
            lastName_mock_dbset = new Mock<DbSet<LastNamePick>>();
            major_mock_dbset = new Mock<DbSet<MajorPick>>();
            student_mock_dbset = new Mock<DbSet<Student>>();

            firstName_datastore = new List<FirstNamePick>();//fake database
            lastName_datastore = new List<LastNamePick>();
            major_datastore = new List<MajorPick>();
            student_datastore = new List<Student>();

            repo = new StudentRepository(mock_context.Object);

            var firstName_queryable_list = firstName_datastore.AsQueryable();
            var lastName_queryable_list = lastName_datastore.AsQueryable();
            var major_queryable_list = major_datastore.AsQueryable();
            var student_queryable_list = student_datastore.AsQueryable();
            
            firstName_mock_dbset.As<IQueryable<FirstNamePick>>().Setup(m => m.Provider).Returns(firstName_queryable_list.Provider);//where data from
            firstName_mock_dbset.As<IQueryable<FirstNamePick>>().Setup(m => m.Expression).Returns(firstName_queryable_list.Expression);//e.g. SQL query is an expression; a big expression could be seperate into two expressions
            firstName_mock_dbset.As<IQueryable<FirstNamePick>>().Setup(m => m.ElementType).Returns(firstName_queryable_list.ElementType);//key words is a element type, e.g. SELECT, FROM; * simbal; table, 3 element type
            firstName_mock_dbset.As<IQueryable<FirstNamePick>>().Setup(m => m.GetEnumerator()).Returns(() => firstName_queryable_list.GetEnumerator());//could loop over ordered

            lastName_mock_dbset.As<IQueryable<LastNamePick>>().Setup(m => m.Provider).Returns(lastName_queryable_list.Provider);//where data from
            lastName_mock_dbset.As<IQueryable<LastNamePick>>().Setup(m => m.Expression).Returns(lastName_queryable_list.Expression);//e.g. SQL query is an expression; a big expression could be seperate into two expressions
            lastName_mock_dbset.As<IQueryable<LastNamePick>>().Setup(m => m.ElementType).Returns(lastName_queryable_list.ElementType);//key words is a element type, e.g. SELECT, FROM; * simbal; table, 3 element type
            lastName_mock_dbset.As<IQueryable<LastNamePick>>().Setup(m => m.GetEnumerator()).Returns(() => lastName_queryable_list.GetEnumerator());

            major_mock_dbset.As<IQueryable<MajorPick>>().Setup(m => m.Provider).Returns(major_queryable_list.Provider);//where data from
            major_mock_dbset.As<IQueryable<MajorPick>>().Setup(m => m.Expression).Returns(major_queryable_list.Expression);//e.g. SQL query is an expression; a big expression could be seperate into two expressions
            major_mock_dbset.As<IQueryable<MajorPick>>().Setup(m => m.ElementType).Returns(major_queryable_list.ElementType);//key words is a element type, e.g. SELECT, FROM; * simbal; table, 3 element type
            major_mock_dbset.As<IQueryable<MajorPick>>().Setup(m => m.GetEnumerator()).Returns(() => major_queryable_list.GetEnumerator());

            student_mock_dbset.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(student_queryable_list.Provider);//where data from
            student_mock_dbset.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(student_queryable_list.Expression);//e.g. SQL query is an expression; a big expression could be seperate into two expressions
            student_mock_dbset.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(student_queryable_list.ElementType);//key words is a element type, e.g. SELECT, FROM; * simbal; table, 3 element type
            student_mock_dbset.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(() => student_queryable_list.GetEnumerator());

            //mock context return the mock_variable_table when someone calls the SavingVariableContext.charValueDb
            mock_context.Setup(c => c.firstNamePick).Returns(firstName_mock_dbset.Object);
            mock_context.Setup(c => c.lastNamePick).Returns(lastName_mock_dbset.Object);
            mock_context.Setup(c => c.majorPick).Returns(major_mock_dbset.Object);
            mock_context.Setup(c => c.Students).Returns(student_mock_dbset.Object);

            //capture when use Add function, instead use variable_datastore
            firstName_mock_dbset.Setup(t => t.Add(It.IsAny<FirstNamePick>())).Callback((FirstNamePick a/*capture the variable sent*/) => firstName_datastore.Add(a)/*add it to a list*/);
            lastName_mock_dbset.Setup(t => t.Add(It.IsAny<LastNamePick>())).Callback((LastNamePick a/*capture the variable sent*/) => lastName_datastore.Add(a)/*add it to a list*/);
            major_mock_dbset.Setup(t => t.Add(It.IsAny<MajorPick>())).Callback((MajorPick a/*capture the variable sent*/) => major_datastore.Add(a)/*add it to a list*/);
            student_mock_dbset.Setup(t => t.Add(It.IsAny<Student>())).Callback((Student a) => student_datastore.Add(a));

            firstName_mock_dbset.Setup(t => t.Remove(It.IsAny<FirstNamePick>())).Callback((FirstNamePick a) => firstName_datastore.Remove(a));
            lastName_mock_dbset.Setup(t => t.Remove(It.IsAny<LastNamePick>())).Callback((LastNamePick a) => lastName_datastore.Remove(a));
            major_mock_dbset.Setup(t => t.Remove(It.IsAny<MajorPick>())).Callback((MajorPick a) => major_datastore.Remove(a));
            student_mock_dbset.Setup(t => t.Remove(It.IsAny<Student>())).Callback((Student a) => student_datastore.Remove(a));
        }

        [TestCleanup]
        public void ClearUp()
        {
            repo = null;
        }

        [TestMethod]
        public void RepoInstanceIsNotNull()
        {
            repo = new StudentRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void EnsureRepoHasContext()
        {
            repo = new StudentRepository();
            StudentContext actualContext = repo.Context;
            Assert.IsNotNull(actualContext);
        }

        [TestMethod]
        public void RepoGetAllStudentsWhenItsEmpty()
        {
            List<Student> student = repo.GetAllStudents();
            Assert.AreEqual(student.Count, 0);
        }

        [TestMethod]
        public void RepoSaveThenGetAllStudents()
        {
            repo.SaveStudentToDb();
            List<Student> student = repo.GetAllStudents();
            Assert.AreEqual(student.Count, 1);
        }

        [TestMethod]
        public void IfDuplicateReturnsFalse()
        {
            var newStudent = new Student() { FirstName = "Bob", LastName = "Williamson", Major = "Industrial Engineering" };
            repo.Context.Students.Add(newStudent);

            var insertStudent = new Student() { FirstName = "Bob", LastName = "Williamson", Major = "Accounting" };
            var testResult = repo.TestIfDuplicate(insertStudent);

            Assert.AreEqual(testResult, false);
        }

        [TestMethod]
        public void IfNotDuplicateReturnsTrue()
        {
            var newStudent = new Student() { FirstName = "Kate", LastName = "Williamson", Major = "Industrial Engineering" };
            repo.Context.Students.Add(newStudent);

            var insertStudent = new Student() { FirstName = "Bob", LastName = "Williamson", Major = "Accounting" };
            var testResult = repo.TestIfDuplicate(insertStudent);

            Assert.AreEqual(testResult, true);
        }

        [TestMethod]
        public void RemoveAStudentCount()
        {
            var newStudent = new Student() { FirstName = "Kate", LastName = "Williamson", Major = "Industrial Engineering" };
            repo.Context.Students.Add(newStudent);
            var student= repo.GetAllStudents();
            Assert.AreEqual(1, student.Count);

            repo.RemoveAStudent(0);
            var student1 = repo.GetAllStudents();
            Assert.AreEqual(0, student1.Count);
        }

        [TestMethod]
        public void ReturnOneStudent()
        {
            var newStudent1 = new Student() { FirstName = "Kate", LastName = "Williamson", Major = "Industrial Engineering" };
            var newStudent2 = new Student() { FirstName = "Sylvia", LastName = "Coury", Major = "Industrial Engineering" };
            repo.Context.Students.Add(newStudent1);
            repo.Context.Students.Add(newStudent2);

            var student = repo.ReturnOneStudent(0);
            Assert.AreEqual(newStudent1.FirstName, student.FirstName);
        }

        [TestMethod]
        public void FirstNamePickList()
        {
            var newFirstName = new FirstNamePick() { FirstName = "Bob" };
            repo.Context.firstNamePick.Add(newFirstName);
            var firstNameList = repo.FirstNamePickList();
            Assert.AreEqual(firstNameList.FirstOrDefault(), newFirstName);
        }

        [TestMethod]
        public void LastNamePickList()
        {
            var newLastName = new LastNamePick() { LastName = "Coury" };
            repo.Context.lastNamePick.Add(newLastName);
            var firstNameList = repo.LastNamePickList();
            Assert.AreEqual(firstNameList.FirstOrDefault(), newLastName);
        }

        [TestMethod]
        public void MajorPickList()
        {
            var major = new MajorPick() { MajorName = "Accounting" };
            repo.Context.majorPick.Add(major);
            var MajorList = repo.MajorPickList();
            Assert.AreEqual(MajorList.FirstOrDefault(), major);
        }

        
    }
}
