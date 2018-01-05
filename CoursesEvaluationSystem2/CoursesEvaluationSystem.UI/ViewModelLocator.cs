using CoursesEvaluationSystem.BL;
using CoursesEvaluationSystem.BL.Repositories;
using CoursesEvaluationSystem.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesEvaluationSystem.UI
{
    public class ViewModelLocator
    {
        private readonly Messenger _messenger = new Messenger();
        private readonly StudentRepository _studentRepository = new StudentRepository();
        private readonly CourseRepository _courseRepository = new CourseRepository();
        private readonly EnrolledCourseRepository _enrolledCourseRepository = new EnrolledCourseRepository();
        private readonly AssessmentRepository _assessmentRepository = new AssessmentRepository();

        public MainViewModel MainViewModel => CreateMainViewModel();

        public StudentListViewModel StudentListViewModel => CreateStudentListViewModel();

        public StudentDetailViewModel StudentDetailViewModel => CreateStudentDetailViewModel();

        public RatingsViewModel RatingsViewModel => CreateRatingsViewModel();

        public AddRatingViewModel AddRatingViewModel => CreateAddRatingViewModel();


        private MainViewModel CreateMainViewModel()
        {
            return new MainViewModel(_courseRepository, _messenger);
        }

        private StudentDetailViewModel CreateStudentDetailViewModel()
        {
            return new StudentDetailViewModel(_studentRepository, _messenger);
        }

        private StudentListViewModel CreateStudentListViewModel()
        {
            return new StudentListViewModel(_studentRepository, _enrolledCourseRepository, _assessmentRepository, _messenger);
        }

        private RatingsViewModel CreateRatingsViewModel()
        {
            return new RatingsViewModel(_assessmentRepository, _enrolledCourseRepository, _messenger);
        }

        private AddRatingViewModel CreateAddRatingViewModel()
        {
            return new AddRatingViewModel(_assessmentRepository, _enrolledCourseRepository, _messenger);
        }
    }
}
