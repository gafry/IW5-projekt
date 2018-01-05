using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesEvaluationSystem.DAL.Entities
{
    public class TeacherEntity : PersonBase
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Room { get; set; }
        public virtual ICollection<CourseEntity> GuaranteedCourses { get; set; } = new List<CourseEntity>();
    }
}
