using CoursesEvaluationSystem.BL.Models;

namespace CoursesEvaluationSystem.BL.Messages
{
    public class UpdatedEnrolledCourseMessage
    {
        public EnrolledCourseModel Model { get; set; }
        public UpdatedEnrolledCourseMessage(EnrolledCourseModel model)
        {
            Model = model;
        }
    }
}
