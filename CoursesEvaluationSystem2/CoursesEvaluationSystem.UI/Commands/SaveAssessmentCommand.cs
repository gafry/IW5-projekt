using CoursesEvaluationSystem.BL;
using CoursesEvaluationSystem.BL.Messages;
using CoursesEvaluationSystem.BL.Models;
using CoursesEvaluationSystem.BL.Repositories;
using CoursesEvaluationSystem.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoursesEvaluationSystem.UI.Commands
{
    public class SaveAssessmentCommand : ICommand
    {
        private readonly AssessmentRepository _assessmentRepository;
        private readonly AddRatingViewModel _viewModel;
        private readonly IMessenger _messenger;

        public SaveAssessmentCommand(AssessmentRepository assessmentRepository, AddRatingViewModel viewModel, IMessenger messenger)
        {
            _assessmentRepository = assessmentRepository;
            _viewModel = viewModel;
            _messenger = messenger;
        }

        public bool CanExecute(object parameter)
        {
            var detail = parameter as AssessmentRatingModel;

            if (detail != null)
            {
                return detail.Points >= 0;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            var detail = parameter as AssessmentRatingModel;

            if (detail == null)
            {
                return;
            }

            if (detail.Id != Guid.Empty)
            {
                _assessmentRepository.UpdateAssessment(detail);
            }
            else
            {
                _viewModel.Assessment = _assessmentRepository.InsertAssessment(detail);
            }

            _messenger.Send(new UpdatedAssessmentRatingMessage(detail));
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
