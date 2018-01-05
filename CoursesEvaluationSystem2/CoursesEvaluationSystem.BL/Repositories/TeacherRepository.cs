using CoursesEvaluationSystem.BL.Models;
using CoursesEvaluationSystem.DAL;
using CoursesEvaluationSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesEvaluationSystem.BL.Repositories
{
    public class TeacherRepository
    {
        private readonly Mapper _mapper = new Mapper();
        public TeacherModel FindTeacherByLogin(string login)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                return
                    courseEvaluationContext.Teachers.Where(r => r.Login == login).Select(_mapper.MapTeacherEntityToTeacherModel).First();
            }
        }
        public List<TeacherModel> GetAllTeachers()
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                return courseEvaluationContext.Teachers.Select(_mapper.MapTeacherEntityToTeacherModel).ToList();
            }
        }
        public TeacherModel GetTeacherById(Guid id)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                return _mapper.MapTeacherEntityToTeacherModel(
                        courseEvaluationContext.Teachers
                        .FirstOrDefault(s => s.Id == id));
            }
        }


        public TeacherModel InsertTeacher(TeacherModel teacher)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                var entity = _mapper.MapTeacherModelToTeacherEntity(teacher);
                entity.Id = Guid.NewGuid();

                courseEvaluationContext.Teachers.Add(entity);
                courseEvaluationContext.SaveChanges();

                return _mapper.MapTeacherEntityToTeacherModel(entity);
            }
        }

        public void UpdateTeacher(TeacherModel teacher)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                var entity = courseEvaluationContext.Teachers.First(s => s.Id == teacher.Id);

                entity.Login = teacher.Login;
                entity.Name = teacher.Name;
                entity.Surname = teacher.Surname;
                entity.Email = teacher.Email;
                entity.Room = teacher.Room;
                //entity.GuaranteedCourses = _mapper.MapCourseModelListToCourseEntityList(teacher.GuaranteedCourses.Select());
                // Nebude fungovat kym nebude instanciovana trieda CourseRepository

                courseEvaluationContext.SaveChanges();
            }
        }

        public void RemoveTeacher(Guid id)
        {
            using (var courseEvaluationContext = new CourseEvaluationContext())
            {
                var entity = new TeacherEntity() { Id = id };
                courseEvaluationContext.Teachers.Attach(entity);
                courseEvaluationContext.Teachers.Remove(entity);
                courseEvaluationContext.SaveChanges();
            }
        }
    }
}
