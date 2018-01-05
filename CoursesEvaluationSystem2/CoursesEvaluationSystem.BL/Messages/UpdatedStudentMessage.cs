using CoursesEvaluationSystem.BL.Models;

namespace CoursesEvaluationSystem.BL.Messages
{
    public class UpdatedStudentMessage
    {
        public StudentModel Model { get; set; }
        public UpdatedStudentMessage(StudentModel model)
        {
            Model = model;
        }
    }
}
