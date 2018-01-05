using CoursesEvaluationSystem.BL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesEvaluationSystem.BL.Models
{
    public class CourseBasicModel : ModelBase
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public DateTime Year { get; set; }
    }
}
