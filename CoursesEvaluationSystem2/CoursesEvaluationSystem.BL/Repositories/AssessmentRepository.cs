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
    public class AssessmentRepository
    {
        private readonly Mapper _mapper = new Mapper();

        public List<AssessmentRatingModel> GetAllRatingsAssignedToStudent(Guid id)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                return courseEvaluationContext.AssessmentRatings
                            .Where(s => s.EnrolledCourse.StudentId == id)
                            .Select(_mapper.MapAssessmentRatingEntityToAssessmentRatingModel).ToList();
            }
        }

        public List<AssessmentRatingModel> GetAllAssessmentsFromEnrolledCourse(Guid id)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                return id == null || id == Guid.Empty ? 
                    new List<AssessmentRatingModel>() :
                    courseEvaluationContext.AssessmentRatings
                    .Where(a => a.EnrolledCourseId == id)
                    .Select(_mapper.MapAssessmentRatingEntityToAssessmentRatingModel)
                    .ToList();
            }
        }

        public AssessmentRatingModel GetAssessmentById(Guid id)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                return _mapper.MapAssessmentRatingEntityToAssessmentRatingModel(
                        courseEvaluationContext.AssessmentRatings
                        .FirstOrDefault(a => a.Id == id));
            }
        }


        public AssessmentRatingModel InsertAssessment(AssessmentRatingModel assessment)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                var entity = _mapper.MapAssessmentRatingModelToAssessmentRatingEntity(assessment);
                entity.Id = Guid.NewGuid();

                courseEvaluationContext.AssessmentRatings.Add(entity);
                courseEvaluationContext.SaveChanges();

                return _mapper.MapAssessmentRatingEntityToAssessmentRatingModel(entity);
            }
        }

        public void UpdateAssessment(AssessmentRatingModel assessment)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                var entity = courseEvaluationContext.AssessmentRatings.First(a => a.Id == assessment.Id);

                entity.Type = assessment.Type;
                entity.Points = assessment.Points;
                entity.Note = assessment.Note;                

                courseEvaluationContext.SaveChanges();
            }
        }

        public void RemoveAssessment(Guid id)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                var entity = new AssessmentRatingEntity() { Id = id };
                courseEvaluationContext.AssessmentRatings.Attach(entity);
                courseEvaluationContext.AssessmentRatings.Remove(entity);
                courseEvaluationContext.SaveChanges();
            }
        }
    }
}
