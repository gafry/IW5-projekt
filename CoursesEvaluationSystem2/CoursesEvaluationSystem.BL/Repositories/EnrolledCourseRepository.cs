using CoursesEvaluationSystem.BL;
using CoursesEvaluationSystem.BL.Models;
using CoursesEvaluationSystem.DAL;
using CoursesEvaluationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesEvaluationSystem.BL.Repositories
{
    public class EnrolledCourseRepository
    {
        private readonly Mapper _mapper = new Mapper();
        public EnrolledCourseModel GetEnrolledCourse(Guid StudentId, Guid CourseId)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                return StudentId == Guid.Empty || StudentId == null || CourseId == Guid.Empty || CourseId == null ?
                    new EnrolledCourseModel() :
                    courseEvaluationContext.EnrolledCourses
                    .Select(_mapper.MapEnrolledCourseEntityToEnrolledCourseModel)
                    .FirstOrDefault(s => s.StudentId == StudentId && s.CourseId == CourseId);

            }
        }
        public bool IsStudentEnrolledInCourse(Guid StudentId, Guid CourseId)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                return courseEvaluationContext.EnrolledCourses
                       .FirstOrDefault(s => s.StudentId == StudentId && s.CourseId == CourseId)
                       != null;

            }
        }
        public EnrolledCourseModel EnrollStudentInCourse(Guid StudentId, Guid CourseId)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                var entity = new EnrolledCourseEntity();
                entity.Id = Guid.NewGuid();
                entity.CourseId = CourseId;
                entity.StudentId = StudentId;

                courseEvaluationContext.EnrolledCourses.Add(entity);
                courseEvaluationContext.SaveChanges();

                return _mapper.MapEnrolledCourseEntityToEnrolledCourseModel(entity);
            }
        }
    }
}
