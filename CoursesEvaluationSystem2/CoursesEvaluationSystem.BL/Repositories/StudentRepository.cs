using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CoursesEvaluationSystem;
using CoursesEvaluationSystem.DAL.Entities;
using CoursesEvaluationSystem.BL.Models;
using System;
using CoursesEvaluationSystem.DAL;

namespace CoursesEvaluationSystem.BL.Repositories
{
    public class StudentRepository
    {
        private readonly  Mapper _mapper = new Mapper();
        public StudentModel FindStudentByLogin(string login)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                return
                    courseEvaluationContext.Students.Where(r => r.Login == login).Select(_mapper.MapStudentEntityToStudentModel).First();
            }
        }

        public List<StudentModel> GetAllStudents()
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                return courseEvaluationContext.Students.Select(_mapper.MapStudentEntityToStudentModel).ToList();
            }
        }
        public List<StudentBasicModel> GetAllStudentsAssignedToCourse(Guid id)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                return courseEvaluationContext.Students
                          .Where(s => s.EnrolledCourses.Any(e => e.CourseId == id))
                          .Select(_mapper.MapStudentEntityToStudentBasicModel).ToList();
            }
        }

        public StudentModel GetStudentById(Guid id)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                return _mapper.MapStudentEntityToStudentModel(
                        courseEvaluationContext.Students
                        .FirstOrDefault(s => s.Id == id));
            }
        }
        public StudentModel GetStudentModelFromStudentBasicModel(StudentBasicModel basicModel)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                return GetStudentById(basicModel.Id);
            }
        }


        public StudentModel InsertStudent(StudentModel student)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                var entity = _mapper.MapStudentModelToStudentEntity(student);
                entity.Id = Guid.NewGuid();

                courseEvaluationContext.Students.Add(entity);
                courseEvaluationContext.SaveChanges();

                return _mapper.MapStudentEntityToStudentModel(entity);
            }
        }

        public void UpdateStudent(StudentModel student)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                var entity = courseEvaluationContext.Students.First(s => s.Id == student.Id);

                entity.Login = student.Login;
                entity.Name = student.Name;
                entity.Surname = student.Surname;
                entity.Address = student.Address;
                entity.Street = student.Street;
                entity.Photo = student.Photo;

                courseEvaluationContext.SaveChanges();
            }
        }

        public void RemoveStudent(Guid id)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                var entity = new StudentEntity() { Id = id };
                courseEvaluationContext.Students.Attach(entity);
                courseEvaluationContext.Students.Remove(entity);
                courseEvaluationContext.SaveChanges();
            }
        }
    }
}
