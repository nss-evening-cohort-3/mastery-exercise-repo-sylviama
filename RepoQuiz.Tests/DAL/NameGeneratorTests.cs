using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.DAL;
using RepoQuiz.Models;

namespace RepoQuiz.Tests.DAL
{
    [TestClass]
    public class NameGeneratorTests
    {
        [TestMethod]
        public void GenerateIsNotNull()
        {
            NameGenerator nameGenerator = new NameGenerator();
            var student=nameGenerator.GenerateRamdomStudentCombination();
            Assert.IsNotNull(student);
        }

        [TestMethod]
        public void GenerateTypeIsStudent()
        {
            NameGenerator nameGenerator = new NameGenerator();
            var student = nameGenerator.GenerateRamdomStudentCombination();
            Assert.AreEqual(student.GetType(), typeof(Student));
        }
    }
}
