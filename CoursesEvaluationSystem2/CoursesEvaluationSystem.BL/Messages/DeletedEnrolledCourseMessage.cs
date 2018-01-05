using System;

namespace CoursesEvaluationSystem.BL.Messages
{
    public class DeletedEnrolledCourseMessage
    {
        public Guid EnrolledCourseId { get; set; }
        public DeletedEnrolledCourseMessage(Guid enrolledCourseId)
        {
            EnrolledCourseId = enrolledCourseId;
        }
    }
}
