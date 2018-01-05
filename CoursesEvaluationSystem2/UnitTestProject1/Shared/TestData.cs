using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesEvaluationSystem.DAL.Entities;

namespace UnitTestProject1.Shared
{
    public class TestData
    {
        public readonly StudentEntity Xmensi03 = new StudentEntity()
        {
            Name = "Jakub",
            Surname = "Mensik",
            Login = "xmensi03",
            Address = "Nachod",
            Street = "Divadelni 9",
            //Grade = 1
        };

        public readonly CourseEntity Iw1 = new CourseEntity()
        {
            Name = "Desktop systémy Microsoft Windows",
            Abbreviation = "IW1",
            //Guarantee = "Honzík Jan"
        };
    }
}
