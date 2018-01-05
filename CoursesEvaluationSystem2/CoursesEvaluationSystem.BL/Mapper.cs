using CoursesEvaluationSystem.BL.Models;
using CoursesEvaluationSystem.BL.Repositories;
using CoursesEvaluationSystem.DAL.Entities;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CoursesEvaluationSystem.BL
{
    public class Mapper
    {
        public StudentModel MapStudentEntityToStudentModel(StudentEntity entity)
        {
            return entity == null ? new StudentModel() : new StudentModel
            {
                Login = entity.Login,
                Name = entity.Name,
                Surname = entity.Surname,
                Id = entity.Id,
                Address = entity.Address,
                Street = entity.Street,
                Photo = entity.Photo,
                Grade = entity.Grade,
                EnrolledCourses = MapEnrolledCourseEntityListToEnrolledCourseModelList(entity.EnrolledCourses)
            };
        }
        public StudentEntity MapStudentModelToStudentEntity(StudentModel model)
        {
            return model == null ? null : new StudentEntity
            {
                Login = model.Login,
                Name = model.Name,
                Surname = model.Surname,
                Id = model.Id,
                Address = model.Address,
                Street = model.Street,
                Photo = model.Photo,
                Grade = model.Grade,
                EnrolledCourses = MapEnrolledCourseModelListToEnrolledCourseEntityList(model.EnrolledCourses)
            };
        }
        public StudentBasicModel MapStudentEntityToStudentBasicModel(StudentEntity entity)
        {
            return entity == null ? new StudentBasicModel() : new StudentBasicModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Login = entity.Login
            };
        }
        public StudentBasicModel MapStudentModelToStudentBasicModel(StudentModel model)
        {
            return model == null ? new StudentBasicModel() : new StudentBasicModel
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Login = model.Login
            };
        }



        public TeacherModel MapTeacherEntityToTeacherModel(TeacherEntity entity)
        {
            return entity == null ? new TeacherModel() : new TeacherModel
            {
                Id = entity.Id,
                Login = entity.Login,
                Name = entity.Name,
                Surname = entity.Surname,
                Room = entity.Room,
                Email = entity.Email,
                GuaranteedCourses = MapCourseEntityListToCourseBasicModelList(entity.GuaranteedCourses)
            };
        }
        public TeacherEntity MapTeacherModelToTeacherEntity(TeacherModel model)
        {
            return model == null ? null : new TeacherEntity
            {
                Id = model.Id,
                Login = model.Login,
                Name = model.Name,
                Surname = model.Surname,
                Room = model.Room,
                Email = model.Email,
                //GuaranteedCourses = MapCourseModelListToCourseEntityList(model.GuaranteedCourses.Select(GetCourseModelFromCourseBasicModel))
                // nebude fungovat kym nebude instanciovana trieda CourseRepository
            };
        }



        public CourseModel MapCourseEntityToCourseModel(CourseEntity entity)
        {
            return entity == null ? new CourseModel() : new CourseModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Abbreviation = entity.Abbreviation,
                GuaranteeId = entity.GuaranteeId,
                //Guarantee = MapTeacherEntityToTeacherModel(entity.Guarantee),
                Year = entity.Year,
                Description = entity.Description,
                EnrolledStudents = MapEnrolledCourseEntityListToEnrolledCourseModelList(entity.EnrolledStudents)
            };
        }
        public CourseEntity MapCourseModelToCourseEntity(CourseModel model)
        {
            return model == null ? null : new CourseEntity
            {
                Id = model.Id,
                Name = model.Name,
                Abbreviation = model.Abbreviation,
                GuaranteeId = model.GuaranteeId,
                //Guarantee = MapTeacherEntityToTeacherModel(model.Guarantee),
                Year = model.Year,
                Description = model.Description,
                EnrolledStudents = MapEnrolledCourseModelListToEnrolledCourseEntityList(model.EnrolledStudents)
            };
        }
        public CourseBasicModel MapCourseEntityToCourseBasicModel(CourseEntity entity)
        {
            return entity == null ? new CourseBasicModel() : new CourseBasicModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Abbreviation = entity.Abbreviation,
                Year = entity.Year
            };
        }



        public EnrolledCourseModel MapEnrolledCourseEntityToEnrolledCourseModel(EnrolledCourseEntity entity)
        {
            return entity == null ? new EnrolledCourseModel() : new EnrolledCourseModel
            {
                Id = entity.Id,
                StudentId = entity.StudentId,
                //Student = MapStudentEntityToStudentModel(entity.Student),
                CourseId = entity.CourseId,
                //Course = MapCourseEntityToCourseModel(entity.Course),
                Assessments = MapAssessmentRatingEntityListToAssessmentRatingModelList(entity.Assessments)
            };
        }
        public EnrolledCourseEntity MapEnrolledCourseModelToEnrolledCourseEntity(EnrolledCourseModel model)
        {
            return model == null ? null : new EnrolledCourseEntity
            {
                Id = model.Id,
                StudentId = model.StudentId,
                //Student = MapStudentEntityToStudentModel(model.Student),
                CourseId = model.CourseId,
                //Course = MapCourseEntityToCourseModel(model.Course),
                Assessments = MapAssessmentRatingModelListToAssessmentRatingEntityList(model.Assessments)
            };
        }


        //public CourseStudentModel MapCourseStudentModel(CourseEntity entity)
        //{
        //    return new CourseStudentModel
        //    {
        //        Abbreviation = entity.Abbreviation,
        //        EnrolledStudents = entity.EnrolledStudents
        //    };
        //}


        public AssessmentRatingModel MapAssessmentRatingEntityToAssessmentRatingModel(AssessmentRatingEntity entity)
        {
            return entity == null ? new AssessmentRatingModel() : new AssessmentRatingModel
            {
                Id = entity.Id,
                Note = entity.Note,
                Points = entity.Points,
                Type = entity.Type,
                EnrolledCourseId = entity.EnrolledCourseId,
                //EnrolledCourse = MapEnrolledCourseEntityToEnrolledCourseModel(entity.EnrolledCourse)
            };
        }
        public AssessmentRatingEntity MapAssessmentRatingModelToAssessmentRatingEntity(AssessmentRatingModel model)
        {
            return model == null ? null : new AssessmentRatingEntity
            {
                Id = model.Id,
                Note = model.Note,
                Points = model.Points,
                Type = model.Type,
                EnrolledCourseId = model.EnrolledCourseId,
                //EnrolledCourse = MapEnrolledCourseEntityToEnrolledCourseModel(model.EnrolledCourse)
            };
        }


        public ICollection<EnrolledCourseModel> MapEnrolledCourseEntityListToEnrolledCourseModelList(ICollection<EnrolledCourseEntity> enrolledCourseEntityList)
        {
            return enrolledCourseEntityList == null ? new List<EnrolledCourseModel>() : new List<EnrolledCourseModel>(((List<EnrolledCourseEntity>)enrolledCourseEntityList)
                                                 .Select(MapEnrolledCourseEntityToEnrolledCourseModel));
        }
        public ICollection<EnrolledCourseEntity> MapEnrolledCourseModelListToEnrolledCourseEntityList(ICollection<EnrolledCourseModel> enrolledCourseModelList)
        {
            return enrolledCourseModelList == null? new List<EnrolledCourseEntity>() : new List<EnrolledCourseEntity>(((List<EnrolledCourseModel>)enrolledCourseModelList)
                                                 .Select(MapEnrolledCourseModelToEnrolledCourseEntity));
        }


        public ICollection<CourseBasicModel> MapCourseEntityListToCourseBasicModelList(ICollection<CourseEntity> courseEntityList)
        {
            return courseEntityList == null? new List<CourseBasicModel>() : new List<CourseBasicModel>(((List<CourseEntity>)courseEntityList)
                                              .Select(MapCourseEntityToCourseBasicModel));
        }
        public ICollection<CourseEntity> MapCourseModelListToCourseEntityList(ICollection<CourseModel> courseModelList)
        {
            return courseModelList == null? new List<CourseEntity>() : new List<CourseEntity>(((List<CourseModel>)courseModelList)
                                         .Select(MapCourseModelToCourseEntity));
        }


        public ICollection<AssessmentRatingModel> MapAssessmentRatingEntityListToAssessmentRatingModelList(ICollection<AssessmentRatingEntity> assessmentRatingEntityList)
        {
            return assessmentRatingEntityList == null? new List<AssessmentRatingModel>() : new List<AssessmentRatingModel>(((List<AssessmentRatingEntity>)assessmentRatingEntityList)
                                                   .Select(MapAssessmentRatingEntityToAssessmentRatingModel));
        }
        public ICollection<AssessmentRatingEntity> MapAssessmentRatingModelListToAssessmentRatingEntityList(ICollection<AssessmentRatingModel> assessmentRatingModelList)
        {
            return assessmentRatingModelList == null? new List<AssessmentRatingEntity>() : new List<AssessmentRatingEntity>(((List<AssessmentRatingModel>)assessmentRatingModelList)
                                                   .Select(MapAssessmentRatingModelToAssessmentRatingEntity));
        }
    }
}
