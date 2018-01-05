
using CoursesEvaluationSystem.BL.Models;
using CoursesEvaluationSystem.DAL;
using CoursesEvaluationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CoursesEvaluationSystem.BL.Repositories
{
    public class CourseRepository
    {
        private readonly Mapper _mapper = new Mapper();
        public List<CourseModel> GetAllCourses()
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                return courseEvaluationContext.Courses.Select(_mapper.MapCourseEntityToCourseModel).ToList();
            }
        }

        public CourseModel GetCourseById(Guid id)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                return _mapper.MapCourseEntityToCourseModel(
                        courseEvaluationContext.Courses
                        .FirstOrDefault(c => c.Id == id));
            }
        }
        public CourseModel GetCourseByAbbreviation(string abbreviation)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                return _mapper.MapCourseEntityToCourseModel(
                        courseEvaluationContext.Courses
                        .FirstOrDefault(c => c.Abbreviation == abbreviation));
            }
        }

        public CourseModel GetCourseModelFromCourseBasicModel(CourseBasicModel basicModel)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                return GetCourseById(basicModel.Id);
            }
        }
        public CourseModel InsertCourse(CourseModel course)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                var entity = _mapper.MapCourseModelToCourseEntity(course);
                entity.Id = Guid.NewGuid();

                courseEvaluationContext.Courses.Add(entity);
                courseEvaluationContext.SaveChanges();

                return _mapper.MapCourseEntityToCourseModel(entity);
            }
        }

        public void UpdateCourse(CourseModel course)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                var entity = courseEvaluationContext.Courses.First(s => s.Id == course.Id);

                entity.Name = course.Name;
                entity.Abbreviation = course.Abbreviation;
                entity.GuaranteeId = course.GuaranteeId;
                entity.Year = course.Year;
                entity.Description = course.Description;

                courseEvaluationContext.SaveChanges();
            }
        }

        public void RemoveCourse(Guid id)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                var entity = new CourseEntity() { Id = id };
                courseEvaluationContext.Courses.Attach(entity);
                courseEvaluationContext.Courses.Remove(entity);
                courseEvaluationContext.SaveChanges();
            }
        }
    }
}

