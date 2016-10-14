using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoQuiz.DAL;
using RepoQuiz.Models;

namespace RepoQuiz.Controllers
{
    public class StudentController : Controller
    {
        StudentRepository repo = new StudentRepository();

        // GET: Student
        public ActionResult Index()
        {
            ViewBag.studentList = repo.GetAllStudents();
            return View();
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.oneStudent = repo.ReturnOneStudent(id);
            return View();
        }

        public ActionResult New()
        {
            ViewBag.generatedNewStudent = repo.SaveStudentToDb();
            return View();
        }

    }
}
