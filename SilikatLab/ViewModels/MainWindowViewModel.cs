using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using SilikatLab.Commands;
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

        #endregion

        #region Свойства

        #region Коллекции

        public ObservableCollection<Laboratorian> Laboratorians { get; } = new();

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

        public MainWindowViewModel(IRepository<Laboratorian> Laboratorians)
        {
            _Laboratorians = Laboratorians;
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

        private void LoadData()
        {
            Load(Laboratorians, _Laboratorians);
        }

        private static void Load<T>(ObservableCollection<T> collection, IRepository<T> repository) where T : Entity
        {
            collection.Clear();
            foreach (var item in repository.GetAll())
                collection.Add(item);
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
