using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesEvaluationSystem.BL.Models.Base;

namespace CoursesEvaluationSystem.BL.Models
{
    public class CourseModel : ModelBase
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public Guid GuaranteeId { get; set; }
        public virtual TeacherModel Guarantee { get; set; }
        public DateTime Year { get; set; }
        public string Description { get; set; }
        public virtual ICollection<EnrolledCourseModel> EnrolledStudents { get; set; }
    }
}
