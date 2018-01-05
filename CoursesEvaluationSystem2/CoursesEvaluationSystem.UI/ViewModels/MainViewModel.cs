using System.ComponentModel;
using CoursesEvaluationSystem.UI.Commands;
using CoursesEvaluationSystem.BL.Messages;
using System.Windows.Input;
using CoursesEvaluationSystem.BL;
using System.Windows.Controls;
using CoursesEvaluationSystem.BL.Repositories;

namespace CoursesEvaluationSystem.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly CourseRepository _courseRepository;

        public ICommand CreateStudentCommand { get; }
        public ICommand SelectCourseCommand { get; }

        public MainViewModel(CourseRepository repository, IMessenger messenger)
        {
            _courseRepository = repository;
            _messenger = messenger;
            SelectCourseCommand = new RelayCommand(CourseSelectionChanged);
            CreateStudentCommand = new RelayCommand(() => _messenger.Send(new NewStudentMessage()));
        }
        public void CourseSelectionChanged(object parameter)
        {
            var openedTab = (string) parameter;

            if (openedTab == null || openedTab == "")
            {
                return;
            }
            
            _messenger.Send(new SelectedCourseMessage() { Id = _courseRepository.GetCourseByAbbreviation(openedTab).Id});
        }
    }
}
