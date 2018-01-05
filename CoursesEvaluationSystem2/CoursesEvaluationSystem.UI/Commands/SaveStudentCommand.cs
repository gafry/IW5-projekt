using CoursesEvaluationSystem.BL;
using CoursesEvaluationSystem.BL.Messages;
using CoursesEvaluationSystem.BL.Models;
using CoursesEvaluationSystem.BL.Repositories;
using CoursesEvaluationSystem.UI.ViewModels;
using System;
using System.Windows.Input;

namespace CoursesEvaluationSystem.UI.Commands
{
    public class SaveStudentCommand : ICommand
    {
        private readonly StudentRepository _studentRepository;
        private readonly StudentDetailViewModel _viewModel;
        private readonly IMessenger _messenger;

        public SaveStudentCommand(StudentRepository studentRepository, StudentDetailViewModel viewModel, IMessenger messenger)
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
                return !string.IsNullOrWhiteSpace(detail.Surname)
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

            if (detail == null)
            {
                return;
            }

            if (detail.Id != Guid.Empty)
            {
                _studentRepository.UpdateStudent(detail);
            }
            else
            {
                _viewModel.Detail = _studentRepository.InsertStudent(detail);
            }

            _messenger.Send(new UpdatedStudentMessage(detail));
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
