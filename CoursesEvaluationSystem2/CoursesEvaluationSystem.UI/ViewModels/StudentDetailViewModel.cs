using CoursesEvaluationSystem.DAL.Entities;
using CoursesEvaluationSystem.UI.Commands;
using CoursesEvaluationSystem.BL.Messages;
using CoursesEvaluationSystem.BL.Models;
using CoursesEvaluationSystem.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CoursesEvaluationSystem.BL;

namespace CoursesEvaluationSystem.UI.ViewModels
{
    public class StudentDetailViewModel : ViewModelBase
    {
        private readonly StudentRepository _studentRepository;
        private readonly IMessenger _messenger;
        private StudentModel _detail;

        public StudentModel Detail
        {
            get { return _detail; }
            set
            {
                if (Equals(value, Detail)) return;

                _detail = value;
                OnPropertyChanged();
            }
        }

        public IList<AssessmentType> AssessmentTypes => Enum.GetValues(typeof(AssessmentType)).Cast<AssessmentType>().ToList();

        public ICommand DeleteCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand NewStudentCommand { get; }
        public ICommand EnrollInCourseCommand { get; }

        public StudentDetailViewModel(StudentRepository studentRepository, IMessenger messenger)
        {
            _studentRepository = studentRepository;
            _messenger = messenger;
            DeleteCommand = new RelayCommand(Delete);
            NewStudentCommand = new RelayCommand(NewStudent);
            SaveCommand = new SaveStudentCommand(studentRepository, this, messenger);
            EnrollInCourseCommand = new EnrollInCourseCommand(studentRepository, this, messenger);

            _messenger.Register<SelectedStudentMessage>(SelectedStudent);
            _messenger.Register<NewStudentMessage>(NewStudentMessageReceived);
        }

        private void NewStudentMessageReceived(NewStudentMessage message)
        {
            Detail = new StudentModel();
        }

        private void SelectedStudent(SelectedStudentMessage message)
        {
            Detail = _studentRepository.GetStudentById(message.Id);
        }

        public void NewStudent()
        {
            Detail = new StudentModel();
        }

        public void Delete()
        {
            if (IsSavedStudent())
            {
                _studentRepository.RemoveStudent(Detail.Id);
                _messenger.Send(new DeletedStudentMessage(Detail.Id));
            }

            Detail = null;
        }

        private bool IsSavedStudent()
        {
            return Detail == null ? false : Detail.Id != Guid.Empty;
        }
    }
}
