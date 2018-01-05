using System;

namespace CoursesEvaluationSystem.BL.Messages
{
    public class EnrollStudentInCurrentCourseMessage
    {
        public Guid StudentId { get; set; }
        public EnrollStudentInCurrentCourseMessage(Guid id)
        {
            StudentId = id;
        }
    }
}
