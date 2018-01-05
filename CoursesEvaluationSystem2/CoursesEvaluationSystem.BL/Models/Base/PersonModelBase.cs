using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesEvaluationSystem.BL.Models.Base
{
    public class PersonModelBase : ModelBase
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
