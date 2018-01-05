using CoursesEvaluationSystem.BL;
using CoursesEvaluationSystem.BL.Messages;
using CoursesEvaluationSystem.BL.Models;
using CoursesEvaluationSystem.BL.Repositories;
using CoursesEvaluationSystem.UI.ViewModels;
using System;
using System.Windows.Input;

namespace CoursesEvaluationSystem.UI.Commands
{
    public class EnrollInCourseCommand : ICommand
    {
        private readonly StudentRepository _studentRepository;
        private readonly StudentDetailViewModel _viewModel;
        private readonly IMessenger _messenger;

        public EnrollInCourseCommand(StudentRepository studentRepository, StudentDetailViewModel viewModel, IMessenger messenger)
        {
            _studentRepository = studentRepository;
            _viewModel = viewModel;
            _messenger = messenger;
        }

        public bool CanExecute(object parameter)
        {
            var detail = parameter as StudentModel;

            if (detail != null)
            {
                return !(detail.Id == Guid.Empty)
                    && !string.IsNullOrWhiteSpace(detail.Surname)
                    && !string.IsNullOrWhiteSpace(detail.Login)
                    && !string.IsNullOrWhiteSpace(detail.Name)
                    //&& !string.IsNullOrWhiteSpace(detail.Grade)
                    && !string.IsNullOrWhiteSpace(detail.Address)
                    && !string.IsNullOrWhiteSpace(detail.Street);
            }

            return false;
        }

        public void Execute(object parameter)
        {
            var detail = parameter as StudentModel;

            _messenger.Send(new EnrollStudentInCurrentCourseMessage(detail.Id));
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
