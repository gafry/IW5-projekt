using CoursesEvaluationSystem.DAL.Entities.Base.Implementation;
using System.ComponentModel.DataAnnotations;

namespace CoursesEvaluationSystem.DAL.Entities
{
    public class PersonBase : EntityBase
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
    }
}