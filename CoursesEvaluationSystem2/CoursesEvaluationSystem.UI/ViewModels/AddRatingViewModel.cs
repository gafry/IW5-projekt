using CoursesEvaluationSystem.BL;
using CoursesEvaluationSystem.BL.Messages;
using CoursesEvaluationSystem.BL.Models;
using CoursesEvaluationSystem.BL.Repositories;
using CoursesEvaluationSystem.DAL.Entities;
using CoursesEvaluationSystem.UI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoursesEvaluationSystem.UI.ViewModels
{
    public class AddRatingViewModel : ViewModelBase
    {
        private AssessmentRatingModel _assessment;
        private readonly AssessmentRepository _assessmentRepository;
        private readonly EnrolledCourseRepository _enrolledCourseRepository;
        private readonly IMessenger _messenger;
        private Guid _course = new Guid("fd0a9192-cec4-4317-a6c1-23131f003bc2");
        private Guid _student;

        public AssessmentRatingModel Assessment
        {
            get { return _assessment; }
            set
            {
                if (Equals(value, _assessment)) return;
                _assessment = value;
                OnPropertyChanged();
            }
        }

        public IList<AssessmentType> AssessmentTypes => Enum.GetValues(typeof(AssessmentType)).Cast<AssessmentType>().ToList();

        public ICommand SelectAssessmentCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand NewAssessmentCommand { get; }

        public AddRatingViewModel(AssessmentRepository assessmentRepository, EnrolledCourseRepository enrolledCourseRepository, IMessenger messenger)
        {
            _assessmentRepository = assessmentRepository;
            _enrolledCourseRepository = enrolledCourseRepository;
            _messenger = messenger;

            DeleteCommand = new RelayCommand(Delete);
            NewAssessmentCommand = new RelayCommand(NewAssessment);
            SaveCommand = new SaveAssessmentCommand(assessmentRepository, this, messenger);

            _messenger.Register<SelectedAssessmentRatingMessage>(SelectedAssessment);
            _messenger.Register<SelectedCourseMessage>(SelectedCourse);
            _messenger.Register<SelectedStudentMessage>(SelectedStudent);
        }

        private void SelectedCourse(SelectedCourseMessage message)
        {
            _course = message.Id;
        }
        private void SelectedStudent(SelectedStudentMessage message)
        {
            _student = message.Id;
        }

        private void NewAssessment()
        {
            Assessment = new AssessmentRatingModel();
            Assessment.EnrolledCourseId = _enrolledCourseRepository.GetEnrolledCourse(_student, _course).Id;
        }

        public void Delete()
        {
            if (IsSavedAssessment())
            {
                _assessmentRepository.RemoveAssessment(Assessment.Id);
                _messenger.Send(new DeletedAssessmentRatingMessage(Assessment.Id));
            }

            Assessment = null;
        }

        private bool IsSavedAssessment()
        {
            return Assessment == null ? false : Assessment.Id != Guid.Empty;
        }

        private void SelectedAssessment(SelectedAssessmentRatingMessage message)
        {
            Assessment = _assessmentRepository.GetAssessmentById(message.Id);
        }
    }
}
