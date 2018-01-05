using System;

namespace CoursesEvaluationSystem.BL.Messages
{
    public class DeletedAssessmentRatingMessage
    {
        public Guid AssessmentRatingId { get; set; }
        public DeletedAssessmentRatingMessage(Guid assessmentRatingId)
        {
            AssessmentRatingId = assessmentRatingId;
        }
    }
}
