using CoursesEvaluationSystem.BL.Models;

namespace CoursesEvaluationSystem.BL.Messages
{
    public class UpdatedCourseMessage
    {
        public CourseModel Model { get; set; }
        public UpdatedCourseMessage(CourseModel model)
        {
            Model = model;
        }
    }
}
