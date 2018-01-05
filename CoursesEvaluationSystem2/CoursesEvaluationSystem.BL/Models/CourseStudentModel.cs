using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesEvaluationSystem.DAL.Entities;

namespace CoursesEvaluationSystem.BL.Models
{
    public class CourseStudentModel
    {

        public string Abbreviation { get; set; }

        public virtual ICollection<EnrolledCourseEntity> EnrolledStudents { get; set; }

    }
}
