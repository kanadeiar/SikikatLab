using System.Windows;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using SilikatLab.Commands;
using SilikatLab.Interfaces;
using SilikatLab.ViewModels.Base;

namespace SilikatLab.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region Свойства

        private string _Title = "Лабораторная программа";

        /// <summary> Заголовок приложения </summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion

        public MainWindowViewModel()
        {
            
        }

        #region Команды

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

    }
}
