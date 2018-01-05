using CoursesEvaluationSystem.DAL.Entities.Base.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CoursesEvaluationSystem.DAL.Entities
{
    public class StudentEntity : PersonBase
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int Grade { get; set; }
        public byte[]  Photo { get; set; }

        public virtual ICollection<EnrolledCourseEntity> EnrolledCourses { get; set; } = new List<EnrolledCourseEntity>();
    }
}
