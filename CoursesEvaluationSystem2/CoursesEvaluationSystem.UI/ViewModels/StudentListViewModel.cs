using System;
using System.Collections.Generic;
using CoursesEvaluationSystem.BL;
using CoursesEvaluationSystem.UI.Commands;
using CoursesEvaluationSystem.BL.Messages;
using CoursesEvaluationSystem.BL.Models;
using CoursesEvaluationSystem.BL.Repositories;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;


namespace CoursesEvaluationSystem.UI.ViewModels
{
    public class StudentListViewModel : ViewModelBase
    {
        private ObservableCollection<StudentBasicModel> _students;
        private ObservableCollection<StudentBasicModel> _selStudents;
        private ObservableCollection<StudentBasicModel> _courseStudents;
        private ObservableCollection<StudentBasicModel> _allStudents;
        private Guid _currentCourseGuid = new Guid("fd0a9192-cec4-4317-a6c1-23131f003bc2"); //IW1
        private readonly StudentRepository _studentRepository;
        private readonly EnrolledCourseRepository _enrolledCourseRepository;
        private readonly AssessmentRepository _assessmentRepository;
        private List<Tuple<Guid, char>> _studentCharRating = new List<Tuple<Guid, char>>();
        private readonly IMessenger _messenger;
        private readonly Mapper _mapper = new Mapper();
        private readonly List<bool> _checkBoxArray = new List<bool>() {true, true, true, true, true, true, };

        public ObservableCollection<StudentBasicModel> Students
        {
            get { return _students; }
            set
            {
                if (Equals(value, _students)) return;
                _students = value;
                OnPropertyChanged();
            }
        }


        public bool AChecked { get { return _checkBoxArray[0]; } set { _checkBoxArray[0] = value; OnPropertyChanged(); } }
        public bool BChecked { get { return _checkBoxArray[1]; } set { _checkBoxArray[1] = value; OnPropertyChanged(); } }
        public bool CChecked { get { return _checkBoxArray[2]; } set { _checkBoxArray[2] = value; OnPropertyChanged(); } }
        public bool DChecked { get { return _checkBoxArray[3]; } set { _checkBoxArray[3] = value; OnPropertyChanged(); } }
        public bool EChecked { get { return _checkBoxArray[4]; } set { _checkBoxArray[4] = value; OnPropertyChanged(); } }
        public bool FChecked { get { return _checkBoxArray[5]; } set { _checkBoxArray[5] = value; OnPropertyChanged(); } }


        public ICommand SelectStudentCommand { get; }
        public ICommand FilterStudentCommand { get; }
        public ICommand SortByNameCommand { get; }
        public ICommand SortBySirNameCommand { get; }
        public ICommand SortByLoginCommand { get; }
        public ICommand SortByCurrentRatingCommand { get; }

        public StudentListViewModel(StudentRepository studentRepository, EnrolledCourseRepository enrolledCourseRepository, 
            AssessmentRepository assessmentRepository, IMessenger messenger)
        {
            _studentRepository = studentRepository;
            _enrolledCourseRepository = enrolledCourseRepository;
            _assessmentRepository = assessmentRepository;
            _messenger = messenger;
            _allStudents = new ObservableCollection<StudentBasicModel>(_studentRepository.GetAllStudents().Select(_mapper.MapStudentModelToStudentBasicModel));

            _messenger.Register<DeletedStudentMessage>(DeletedStudentMessageReceived);
            _messenger.Register<SelectedCourseMessage>(SelectedCourseMessageReceived);
            _messenger.Register<EnrollStudentInCurrentCourseMessage>(EnrollStudentInCourseReceived);
            _messenger.Register<UpdatedStudentMessage>((p) => OnLoad());
            SelectStudentCommand = new RelayCommand(StudentSelectionChanged);
            FilterStudentCommand = new RelayCommand(FilterStudentChanged);
            SortByNameCommand = new RelayCommand(SortByName);
            SortBySirNameCommand = new RelayCommand(SortBySurName);
            SortByLoginCommand = new RelayCommand(SortByLogin);
            SortByCurrentRatingCommand = new RelayCommand(SortByCurrentRating);
        }

        public void SortByName(object parameter)
        {
            Students = new ObservableCollection<StudentBasicModel>(_studentRepository.GetAllStudentsAssignedToCourse(_currentCourseGuid));
            FilterStudents();
            Students = new ObservableCollection<StudentBasicModel>(Students.OrderBy(s => s.Name));
        }
        public void SortBySurName(object parameter)
        {
            Students = new ObservableCollection<StudentBasicModel>(_studentRepository.GetAllStudentsAssignedToCourse(_currentCourseGuid));
            FilterStudents();
            Students = new ObservableCollection<StudentBasicModel>(Students.OrderBy(s => s.Surname));
        }
        public void SortByLogin(object parameter)
        {
            Students = new ObservableCollection<StudentBasicModel>(_studentRepository.GetAllStudentsAssignedToCourse(_currentCourseGuid));
            FilterStudents();
            Students = new ObservableCollection<StudentBasicModel>(Students.OrderBy(s => s.Login));
        }
        public void SortByCurrentRating(object parameter)
        {
            Students = new ObservableCollection<StudentBasicModel>(_studentRepository.GetAllStudentsAssignedToCourse(_currentCourseGuid));
            FilterStudents();
            var sortedStudents = new ObservableCollection<StudentBasicModel>();
             _studentCharRating.Sort((x, y) => y.Item2.CompareTo(x.Item2));
            Students = new ObservableCollection<StudentBasicModel>();
            foreach (var charRating in _studentCharRating)
            {
                var student = Students.FirstOrDefault(s => s.Id == charRating.Item1);
                sortedStudents.Add(student);
            }
            Students = sortedStudents;
        }


        private void FilterStudents()
        {
            Students = new ObservableCollection<StudentBasicModel>(_studentRepository.GetAllStudentsAssignedToCourse(_currentCourseGuid));
            _selStudents = new ObservableCollection<StudentBasicModel>();
            var charRatingsToKeep = ConvertCheckBoxArrayToCharRatingToKeep();
            var idsToKeep = (from studentCharRating in _studentCharRating
                             where charRatingsToKeep.Contains(studentCharRating.Item2)
                             select studentCharRating.Item1).ToList();
            foreach (var student in _students)
            {
                if (idsToKeep.Contains(student.Id))
                    _selStudents.Add(student);
            }
            Students = new ObservableCollection<StudentBasicModel>(_selStudents);
        }

        public void FilterStudentChanged(object parameter)
        {
            FilterStudents();
        }

        private List<char> ConvertCheckBoxArrayToCharRatingToKeep()
        {
            var returnList = new List<char>();
            var currentChar = 'A';
            foreach (var _checked in _checkBoxArray)
            {
                if (_checked)
                {
                    returnList.Add(currentChar);
                }
                currentChar++;
            }
            return returnList;
        }

        private char ConvertPointsToCharRating(int points)
        {
            if (points >= 90)
                return 'A';
            if (points >= 80)
                return 'B';
            if (points >= 70)
                return 'C';
            if (points >= 60)
                return 'D';
            return points >= 50 ? 'E' : 'F';
        }


        public void OnLoad()
        {
            _courseStudents = new ObservableCollection<StudentBasicModel>(_studentRepository.GetAllStudentsAssignedToCourse(_currentCourseGuid));
            Students = new ObservableCollection<StudentBasicModel>(_courseStudents);
            _studentCharRating = new List<Tuple<Guid, char>>();
            foreach (var student in _courseStudents)
            {
                var ratings = _assessmentRepository.GetAllRatingsAssignedToStudent(student.Id);
                var allPoints = ratings.Sum(rating => rating.Points);
                _studentCharRating.Add(new Tuple<Guid, char>(student.Id, ConvertPointsToCharRating(allPoints)));
            }
            
        }

        public void StudentSelectionChanged(object parameter)
        {
            var studentId = (StudentBasicModel)parameter;

            if (studentId == null)
            {
                return;
            }

            _messenger.Send(new SelectedStudentMessage() { Id = studentId.Id });
        }

        private void DeletedStudentMessageReceived(DeletedStudentMessage message)
        {
            var deletedStudent = Students.FirstOrDefault(r => r.Id == message.StudentId);
            if (deletedStudent != null)
            {
                Students.Remove(deletedStudent);
                _courseStudents.Remove(deletedStudent);
                _allStudents.Remove(deletedStudent);
            }
        }
        private void SelectedCourseMessageReceived(SelectedCourseMessage message)
        {
            _currentCourseGuid = message.Id;
            _courseStudents = new ObservableCollection<StudentBasicModel>(_studentRepository.GetAllStudentsAssignedToCourse(_currentCourseGuid));
            Students = new ObservableCollection<StudentBasicModel>(_courseStudents);
        }
        private void EnrollStudentInCourseReceived(EnrollStudentInCurrentCourseMessage message)
        {
            if (!_enrolledCourseRepository.IsStudentEnrolledInCourse(message.StudentId, _currentCourseGuid))
            {
                var enrolledCourse = _enrolledCourseRepository.EnrollStudentInCourse(message.StudentId, _currentCourseGuid);
                Students.Add(_mapper.MapStudentModelToStudentBasicModel(_studentRepository.GetStudentById(enrolledCourse.StudentId)));
            }
            

        }
    }
}
