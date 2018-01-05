using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoursesEvaluationSystem;
using CoursesEvaluationSystem.DAL.Entities;
using UnitTestProject1.Shared;
using CoursesEvaluationSystem.DAL;

namespace UnitTestProject1
{
    [TestClass]
    public class DALTests
    {
        public DALTests()
        {
            Database.SetInitializer<CourseEvaluationContext>(null);
        }

        private readonly TestData _data = new TestData();

        public readonly StudentEntity s = new StudentEntity()
        {
            Name = "Jsakub",
            Surname = "Msensik",
            Login = "blabsla",
            Address = "Nsachod",
            Street = "Divadelni 9",
        };



        [TestMethod]
        public void CreateNewContext_CreateContext_NotNull()
        {
            using (var dbTest = new CourseEvaluationContext())
            {
                Assert.IsNotNull(dbTest);
            }
        }

        [TestMethod]
        public void AddStudentToDB_AddStudent_Added()
        {
            using (var dbTest = new CourseEvaluationContext())
            {

                dbTest.Students.Add(_data.Xmensi03);
                var students = dbTest.Students.Where(n => n.Login == _data.Xmensi03.Login).Select(n => n.Login).ToList();
                Assert.IsTrue(students.Any());
                dbTest.Students.Remove(_data.Xmensi03);
            }
        }

        [TestMethod]
        public void AddCourseToDB_AddCourse_Added()
        {
            using (var dbTest = new CourseEvaluationContext())
            {

                dbTest.Courses.Add(_data.Iw1);
                var course = dbTest.Courses.Where(n => n.Abbreviation == _data.Iw1.Abbreviation).Select(n => n.Abbreviation).ToList();
                Assert.IsTrue(course.Any());
                dbTest.Courses.Remove(_data.Iw1);
            }
        }

        [TestMethod]
        public void FindNonExistingStudent_FindStudent_False()
        {
            using (var dbTest = new CourseEvaluationContext())
            {
                var student = dbTest.Students.Select(n => n.Login == "xnikdo06").SingleOrDefault();
                Assert.IsFalse(student);
            }
        }


        [TestMethod]
        public void AssignPointToStudent_AssignedPoints_PointsAssigned()
        {
            using (var dbTest = new CourseEvaluationContext())
            {
                var enrolledCourse = new EnrolledCourseEntity();
                var student = _data.Xmensi03;
                var points = 15;

                var rating1 = new AssessmentRatingEntity()
                {
                    Points = points,
                    Type = AssessmentType.Examination
                };

                enrolledCourse.Assessments.Add(rating1);
                student.EnrolledCourses.Add(enrolledCourse);
                dbTest.Students.Add(student);
                var assignedPoints = dbTest
                    .Students
                    .Single(n => n.Login == student.Login)
                    .EnrolledCourses
                    .First()
                    .Assessments
                    .First()
                    .Points;
                Assert.AreEqual(points, assignedPoints);
                enrolledCourse.Assessments.Remove(rating1);
                student.EnrolledCourses.Remove(enrolledCourse);
                dbTest.Students.Remove(student);
            }

        }
    }
}

