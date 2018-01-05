using CoursesEvaluationSystem.BL;
using CoursesEvaluationSystem.BL.Messages;
using CoursesEvaluationSystem.BL.Models;
using CoursesEvaluationSystem.BL.Repositories;
using CoursesEvaluationSystem.UI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoursesEvaluationSystem.UI.ViewModels
{
    public class RatingsViewModel : ViewModelBase
    {
        private ObservableCollection<AssessmentRatingModel> _assessments;
        private readonly AssessmentRepository _assessmentRepository;
        private readonly EnrolledCourseRepository _enrolledCourseRepository;
        private readonly IMessenger _messenger;
        private Guid _studentId;
        private Guid _courseId;

        public ObservableCollection<AssessmentRatingModel> Assessments
        {
            get { return _assessments; }
            set
            {
                if (Equals(value, _assessments)) return;
                _assessments = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectAssessmentCommand { get; }

        public RatingsViewModel(AssessmentRepository assessmentRepository, EnrolledCourseRepository enrolledCourseRepository, IMessenger messenger)
        {
            _assessmentRepository = assessmentRepository;
            _enrolledCourseRepository = enrolledCourseRepository;
            _messenger = messenger;

            _messenger.Register<SelectedStudentMessage>(SelectedStudent);
            _messenger.Register<SelectedCourseMessage>(SelectedCourse);
            _messenger.Register<UpdatedAssessmentRatingMessage>((p) => LoadAssessments());
            _messenger.Register<DeletedAssessmentRatingMessage>((p) => LoadAssessments());
            SelectAssessmentCommand = new RelayCommand(AssessmentSelectionChanged);
        }

        public void LoadAssessments()
        {
            var enrolledCourse = _enrolledCourseRepository.GetEnrolledCourse(_studentId, _courseId);
            if(enrolledCourse != null)
                Assessments = new ObservableCollection<AssessmentRatingModel>(_assessmentRepository
                .GetAllAssessmentsFromEnrolledCourse(enrolledCourse.Id));
        }

        public void AssessmentSelectionChanged(object parameter)
        {
            var assessmentId = (AssessmentRatingModel)parameter;

            if (assessmentId == null)
            {
                return;
            }
            
            _messenger.Send(new SelectedAssessmentRatingMessage() { Id = assessmentId.Id });
        }

        public void SelectedStudent(SelectedStudentMessage message)
        {
            _studentId = message.Id;
            LoadAssessments();
        }

        public void SelectedStudent()
        {
            LoadAssessments();
        }
        private void SelectedCourse(SelectedCourseMessage message)
        {
            _courseId = message.Id;
            Assessments = new ObservableCollection<AssessmentRatingModel>();
            LoadAssessments();
        }
    }
}

