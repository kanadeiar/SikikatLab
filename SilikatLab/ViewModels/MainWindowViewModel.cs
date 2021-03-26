using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SilikatLab.Commands;
using SilikatLab.lib.Data.Base;
using SilikatLab.lib.Interfaces;
using SilikatLab.lib.Models;
using SilikatLab.lib.Models.Base;
using SilikatLab.ViewModels.Base;
using SilikatLab.Windows;

namespace SilikatLab.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region Данные

        private readonly IRepository<Laboratorian> _Laboratorians;
        private readonly IRepository<ResearchObject> _ResearchObjects;
        private readonly IRepository<TypeResearch> _TypeResearches;
        private readonly IRepository<UserLogin> _UserLogins;
        private readonly IRepository<WorkShift> _WorkShifts;
        private readonly IRepository<WorkTask> _WorkTasks;
        private readonly IRepository<Research> _Researches;

        /// <summary> Загрузка из хранилища в коллекции </summary>
        private void LoadData()
        {
            Load(Laboratorians, _Laboratorians);
            Load(ResearchObjects, _ResearchObjects);
            Load(TypeResearches, _TypeResearches);
            Load(UserLogins, _UserLogins);
            Load(WorkShifts, _WorkShifts);
            Load(WorkTasks, _WorkTasks);
            Load(Researches, _Researches);
        }
        #endregion

        #region Свойства

        #region Коллекции

        public ObservableCollection<Laboratorian> Laboratorians { get; } = new();
        public ObservableCollection<ResearchObject> ResearchObjects { get; } = new();
        public ObservableCollection<TypeResearch> TypeResearches { get; } = new();
        public ObservableCollection<UserLogin> UserLogins { get; } = new();
        public ObservableCollection<WorkShift> WorkShifts { get; } = new();
        public ObservableCollection<WorkTask> WorkTasks { get; } = new();
        public ObservableCollection<Research> Researches { get; } = new();

        #endregion

        private WorkTask _SelectedWorkTaskMain;

        /// <summary> Выбранное задание в главном окне на первой вкладке </summary>
        public WorkTask SelectedWorkTaskMain
        {
            get => _SelectedWorkTaskMain;
            set
            {
                Set(ref _SelectedWorkTaskMain, value);
                OnPropertyChanged(nameof(DayResearchesOfSelectedWorkTaskMain));
            }
        }

        private Research _SelectedResearchMain;

        /// <summary> Выбранный результат исследования во вкладке результатов </summary>
        public Research SelectedResearchMain
        {
            get => _SelectedResearchMain;
            set => Set(ref _SelectedResearchMain, value);
        }

        private Research _SelectedResearchArch;

        /// <summary> Выбранный результат исследования во вкладке архива </summary>
        public Research SelectedResearchArch
        {
            get => _SelectedResearchArch;
            set => Set(ref _SelectedResearchArch, value);
        }

        public IEnumerable<Research> DayResearchesOfSelectedWorkTaskMain =>
            Researches.Where(r => r.WorkTask == SelectedWorkTaskMain && r.DateTime >= DateTime.Now.AddDays(- 1));

        public IEnumerable<Research> DayResearchesMain =>
            Researches.Where(r => r.DateTime >= DateTime.Now.AddDays(- 1));

        public IEnumerable<Laboratorian> AddNewResearchWindowLaboratorians =>
            Laboratorians.Where(l => l.Inactive == false);

        public IEnumerable<WorkTask> AddNewResearchWindowWorkTasks
        {
            get
            {
                var tasks = new List<WorkTask>();
                tasks.Add(new WorkTask
                {
                    Name = "<Отсутствует задание>",
                });
                tasks.AddRange(WorkTasks);
                return tasks;
            }
        }
            

        #region Вспомогательные

        private string _Title = "Лабораторная программа";

        /// <summary> Заголовок приложения </summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion

        #endregion

        public MainWindowViewModel(IRepository<Laboratorian> Laboratorians, 
            IRepository<ResearchObject> ResearchObjects, 
            IRepository<TypeResearch> TypeResearches, 
            IRepository<UserLogin> UserLogins,
            IRepository<WorkShift> WorkShifts,
            IRepository<WorkTask> WorkTasks,
            IRepository<Research> Researches)
        {
            UpdateDatabase();
            _Laboratorians = Laboratorians;
            _ResearchObjects = ResearchObjects;
            _TypeResearches = TypeResearches;
            _UserLogins = UserLogins;
            _WorkShifts = WorkShifts;
            _WorkTasks = WorkTasks;
            _Researches = Researches;
            //LoadData();
        }



        #region Команды
        
        #region Данные

        private ICommand _LoadDataCommand;

        /// <summary> Загрузка данных </summary>
        public ICommand LoadDataCommand => _LoadDataCommand ??=
            new LambdaCommand(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        private bool CanLoadDataCommandExecute(object p) => true;

        private void OnLoadDataCommandExecuted(object p)
        {
            LoadData();
            OnPropertyChanged(nameof(DayResearchesMain));
        }

        /// <summary> Загрузка из хранилища в коллекцию </summary>
        private static void Load<T>(ObservableCollection<T> collection, IRepository<T> repository) where T : Entity
        {
            collection.Clear();
            var all = repository.GetAll().ToList();
            foreach (var item in repository.GetAll())
                collection.Add(item);
        }

        /// <summary> Обновление через миграции базы данных </summary>
        private static void UpdateDatabase()
        {
            var options = new DbContextOptionsBuilder<SPLaboratoryEntities>()
                .UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString).Options;
            using (var db = new SPLaboratoryEntities(options))
            {
                db.Database.Migrate();
                //SPLaboratoryEntities.AddTestData(db);
            }
        }

        #endregion

        private ICommand _ShowAddNewResearchWindowdCommand;

        /// <summary> Команда показа окна добавления нового результата </summary>
        public ICommand ShowAddNewResearchWindowdCommand => _ShowAddNewResearchWindowdCommand ??=
            new LambdaCommand(OnShowAddNewResearchWindowdCommandExecuted, CanShowAddNewResearchWindowdCommandExecute);

        private bool CanShowAddNewResearchWindowdCommandExecute(object p) => SelectedWorkTaskMain?.TypeResearch?.TypeResult == TypeResearch.IsTypeResult.Simple;

        private void OnShowAddNewResearchWindowdCommandExecuted(object p)
        {
            var window = new AddNewResearchWindow();
            window.Owner = Application.Current.Windows.Cast<Window>()
                .FirstOrDefault(win => win.IsActive);
            window.TargetTypeResearch = SelectedWorkTaskMain.TypeResearch;
            window.TargetResearchObject = SelectedWorkTaskMain.ResearchObject;
            window.TargetWorkTask = SelectedWorkTaskMain;
            if (window.ShowDialog() == true)
            {
                var result = window.Research;
                _Researches.Add(result);
                Researches.Add(result);
                OnPropertyChanged(nameof(DayResearchesOfSelectedWorkTaskMain));
                OnPropertyChanged(nameof(DayResearchesMain));
            }
        }

        private ICommand _ShowViewResearchWindowCommand;

        /// <summary> Команда показа окна с подробными данными по результату </summary>
        public ICommand ShowViewResearchWindowCommand => _ShowViewResearchWindowCommand ??=
            new LambdaCommand(OnShowViewResearchWindowCommandExecuted, CanShowViewResearchWindowCommandExecute);

        private bool CanShowViewResearchWindowCommandExecute(object p) => SelectedResearchMain != null;

        private void OnShowViewResearchWindowCommandExecuted(object p)
        {
            var window = new ShowViewResearchWindow();
            window.Owner = Application.Current.Windows.Cast<Window>()
                .FirstOrDefault(win => win.IsActive);
            window.Research = SelectedResearchMain;
            window.ShowDialog();
        }

        private ICommand _ShowViewResearchArchiveWindowCommand;

        /// <summary> Команда показа окна с подробными данными по результату из архива </summary>
        public ICommand ShowViewResearchArchiveWindowCommand => _ShowViewResearchArchiveWindowCommand ??=
            new LambdaCommand(OnShowViewResearchArchiveWindowCommandExecuted, CanShowViewResearchArchiveWindowCommandExecute);

        private bool CanShowViewResearchArchiveWindowCommandExecute(object p) => SelectedResearchArch != null;

        private void OnShowViewResearchArchiveWindowCommandExecuted(object p)
        {
            var window = new ShowViewResearchWindow();
            window.Owner = Application.Current.Windows.Cast<Window>()
                .FirstOrDefault(win => win.IsActive);
            window.Research = SelectedResearchArch;
            window.ShowDialog();
        }

        #region Вспомогательные

        private ICommand _ShowDialogCommand;

        /// <summary> Показ сообщения </summary>
        public ICommand ShowDialogCommand => _ShowDialogCommand ??=
            new LambdaCommand(OnShowDialogCommandExecuted);

        private void OnShowDialogCommandExecuted(object p)
        {
            var message = p as string ?? "Простое сообщение";
            App.Services.GetService<IDialogService>()?.ShowInfo(message);
        }

        private ICommand _CloseApplicationCommand;

        /// <summary> Команда закрытия приложения </summary>
        public ICommand CloseApplicationCommand => _CloseApplicationCommand ??=
            new LambdaCommand(OnCloseApplicationCommandExecuted);

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion

        #endregion

    }
}
