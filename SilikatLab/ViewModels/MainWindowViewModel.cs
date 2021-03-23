using System.Collections.ObjectModel;
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
            //UpdateDatabase();
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
        }

        /// <summary> Загрузка из хранилища в коллекцию </summary>
        private static void Load<T>(ObservableCollection<T> collection, IRepository<T> repository) where T : Entity
        {
            collection.Clear();
            var all = repository.GetAll().ToList();
            foreach (var item in repository.GetAll())
                collection.Add(item);
        }

        /// <summary> Обновление базы данных </summary>
        private static void UpdateDatabase()
        {
            using (var db = new SPLaboratoryEntities())
            {
                db.Database.Migrate();
            }
        }

        #endregion



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
