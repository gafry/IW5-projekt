using CoursesEvaluationSystem.BL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesEvaluationSystem.BL.Models
{
    public class TeacherModel : PersonModelBase
    {
        public string Email { get; set; }
        public string Room { get; set; }
        public virtual ICollection<CourseBasicModel> GuaranteedCourses { get; set; }
    }
}
