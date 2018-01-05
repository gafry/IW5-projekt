using CoursesEvaluationSystem.DAL.Entities.Base.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesEvaluationSystem.DAL.Entities
{
    public class AssessmentRatingEntity : EntityBase
    {
        [Required]
        public AssessmentType Type { get; set; }
        [Required]
        public int Points { get; set; }
        public string Note { get; set; }
        [Required]
        public Guid EnrolledCourseId { get; set; }
        public virtual EnrolledCourseEntity EnrolledCourse { get; set; }
    }

    public enum AssessmentType
    {
        Exercise = 1,
        Project,
        Examination,
        BonusPoints,
        Other
    }
}
