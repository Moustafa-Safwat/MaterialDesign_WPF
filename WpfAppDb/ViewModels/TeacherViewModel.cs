using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppDb.Command;
using WpfAppDb.Models;
using WpfAppDb.Services.Interfaces;
using WpfAppDb.ViewModels.Interfaces;

namespace WpfAppDb.ViewModels
{
    internal class TeacherViewModel : BaseViewModel, ITeacherViewModel
    {

        #region Private Fields
        private ITeacherService _teacherService;
        private ObservableCollection<Teacher> _teachers = new();
        #endregion

        #region Binding Properties
        public ObservableCollection<Teacher> Teachers
        {
            get => _teachers;
            set { _teachers = value; OnPropertyChanged(); }
        }
        public Teacher TeacherToAdd { get; set; } = new();
        public ICommand SaveTeacherCommand { get; }
        #endregion

        #region Constructor
        public TeacherViewModel(ITeacherService teacherService)
        {
            _teacherService = teacherService;
            BindDateToView();
            SaveTeacherCommand = new RelayCommand<int>(SaveTeacher);
        }
        #endregion

        #region Methods
        public void BindDateToView()
        {
            AddTeacherRandomData();
            var teacherList = _teacherService.GetAll();
            Teachers = new ObservableCollection<Teacher>(teacherList);
        }

        private void SaveTeacher()
        {
            _teacherService.Add(TeacherToAdd);
            Teachers = new ObservableCollection<Teacher>(_teacherService.GetAll());
        }

        private void AddTeacherRandomData()
        {
            List<string> names = new List<string>()
            {
                "Ahmed","Sayed","Moustafa","Magedy","Safwat","Hessan","Salah"
            };
            List<string> cities = new List<string>()
            {
                "Cairo","Alex","Aswan","Tanta"
            };

            int noNames = names?.Count ?? 0;
            int noCities = cities?.Count ?? 0;

            for (int i = 0; i < noNames; i++)
            {
                _teacherService.Add(new Teacher
                {
                    Id = i,
                    Name = names?[i] ?? string.Empty,
                    Address = cities?[(i % noCities)] ?? string.Empty,
                    Email = $"{names?[i] ?? string.Empty}@gmail.com",
                    Salary = 15_000
                });
            }
        }
        #endregion

    }
}
