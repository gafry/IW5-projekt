using System;

namespace CoursesEvaluationSystem.BL.Messages
{
    public class DeletedCourseMessage
    {
        public Guid CourseId { get; set; }
        public DeletedCourseMessage(Guid courseId)
        {
            CourseId = CourseId;
        }
    }
}
