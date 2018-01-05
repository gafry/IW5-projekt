using CoursesEvaluationSystem.BL.Models.Base;
using System;
using System.Collections.Generic;

namespace CoursesEvaluationSystem.BL.Models
{
    public class StudentModel : PersonModelBase
    {
        public string Address { get; set; }
        public string Street { get; set; }
        public int Grade { get; set; }
        public byte[] Photo { get; set; }
        public virtual ICollection<EnrolledCourseModel> EnrolledCourses { get; set; }
    }
}
