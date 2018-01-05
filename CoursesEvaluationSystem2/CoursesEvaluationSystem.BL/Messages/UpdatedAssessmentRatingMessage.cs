using CoursesEvaluationSystem.BL.Models;

namespace CoursesEvaluationSystem.BL.Messages
{
    public class UpdatedAssessmentRatingMessage
    {
        public AssessmentRatingModel Model { get; set; }
        public UpdatedAssessmentRatingMessage(AssessmentRatingModel model)
        {
            Model = model;
        }
    }
}
