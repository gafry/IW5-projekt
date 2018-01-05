using System;

namespace CoursesEvaluationSystem.BL.Messages
{
    public class DeletedStudentMessage
    {
        public Guid StudentId { get; set; }
        public DeletedStudentMessage(Guid studentId)
        {
            StudentId = studentId;
        }
    }
}
