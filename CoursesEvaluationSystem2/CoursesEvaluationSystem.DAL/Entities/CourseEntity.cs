using CoursesEvaluationSystem.DAL.Entities.Base.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesEvaluationSystem.DAL.Entities
{
    public class CourseEntity : EntityBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abbreviation { get; set; }
        [Required]
        public Guid GuaranteeId { get; set; }
        public virtual TeacherEntity Guarantee { get; set; }
        [Required]
        public DateTime Year { get; set; }
        public string Description { get; set; }
        public virtual ICollection<EnrolledCourseEntity> EnrolledStudents { get; set; } = new List<EnrolledCourseEntity>();
    }
}
