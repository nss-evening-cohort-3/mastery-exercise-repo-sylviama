using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.Controllers;
using RepoQuiz.DAL;
using RepoQuiz.Models;
using RepoQuiz.Tests;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;

namespace RepoQuiz.Tests.Controllers
{
    [TestClass]
    public class StudentControllerTest
    {
        Mock<StudentRepository> mock_repo;
        Mock<StudentContext> mock_context { get; set; }
        Mock<DbSet<Student>> student_mock_dbset { get; set; }
        List<Student> student_datastore { get; set; }
        StudentRepository repo { get; set; }
        
        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<StudentContext>();
            student_mock_dbset = new Mock<DbSet<Student>>();
            student_datastore = new List<Student>();
            repo = new StudentRepository(mock_context.Object);
            mock_repo = new Mock<StudentRepository>();
            var student_queryable_list = student_datastore.AsQueryable();

            student_mock_dbset.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(student_queryable_list.Provider);//where data from
            student_mock_dbset.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(student_queryable_list.Expression);//e.g. SQL query is an expression; a big expression could be seperate into two expressions
            student_mock_dbset.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(student_queryable_list.ElementType);//key words is a element type, e.g. SELECT, FROM; * simbal; table, 3 element type
            student_mock_dbset.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(() => student_queryable_list.GetEnumerator());

            //mock context return the mock_variable_table when someone calls the SavingVariableContext.charValueDb
       
            mock_context.Setup(c => c.Students).Returns(student_mock_dbset.Object);
            mock_repo.Setup(x => x.GetAllStudents()).Returns(student_datastore);

            //capture when use Add function, instead use variable_datastore

            student_mock_dbset.Setup(t => t.Add(It.IsAny<Student>())).Callback((Student a) => student_datastore.Add(a));
        
            student_mock_dbset.Setup(t => t.Remove(It.IsAny<Student>())).Callback((Student a) => student_datastore.Remove(a));
        }

        [TestCleanup]
        public void ClearUp()
        {
            repo = null;
            student_datastore = null;
        }
    

       

        [TestMethod]
        public void CanMakeInstanceOfStudentController()
        {
            StudentController studentController = new StudentController();
            Assert.IsNotNull(studentController);
        }

        [TestMethod]
        public void CanMakeStudentControllerWithStudentRepo()
        {
            StudentController studentController = new StudentController(mock_repo.Object);
            Assert.IsNotNull(studentController);
        }

        [TestMethod]
        public void Index()
        {
            StudentController controller = new StudentController(mock_repo.Object);
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void StudentControllerCanReturnAllStudents()
        {
            Student student1 = new Student() { FirstName = "Bob", LastName = "Williams", Major = "Accounting" };
            Student student2 = new Student() { FirstName = "Kate", LastName = "Coury", Major = "Engineering" };
            repo.Context.Students.Add(student1);
            repo.Context.Students.Add(student2);

            StudentController controller = new StudentController(mock_repo.Object);
            ViewResult result = controller.Index() as ViewResult;
            var actual_student = result.ViewBag.studentList;
            CollectionAssert.AreEqual(actual_student, student_datastore);
        }

        [TestMethod]
        public void Details()
        {
            Student student1 = new Student() { FirstName = "Bob", LastName = "Williams", Major = "Accounting" };
            Student student2 = new Student() { FirstName = "Kate", LastName = "Coury", Major = "Engineering" };
            repo.Context.Students.Add(student1);
            repo.Context.Students.Add(student2);
            
            StudentController controller = new StudentController(mock_repo.Object);
            ViewResult result = controller.Details(0) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void StudentControllerCanReturnDetails()
        {
            Student student1 = new Student() { FirstName = "Bob", LastName = "Williams", Major = "Accounting" };
            Student student2 = new Student() { FirstName = "Kate", LastName = "Coury", Major = "Engineering" };
            repo.Context.Students.Add(student1);
            repo.Context.Students.Add(student2);

            StudentController controller = new StudentController(mock_repo.Object);
            ViewResult result = controller.Details(0) as ViewResult;
            var actual_detail = result.ViewBag.oneStudent;
            Assert.AreEqual(actual_detail.FirstName, student1.FirstName);
        }

        [TestMethod]
        public void New()
        {
            StudentController controller = new StudentController(mock_repo.Object);
            ViewResult result = controller.New() as ViewResult;
            Assert.IsNotNull(result);
        }




    }
}
