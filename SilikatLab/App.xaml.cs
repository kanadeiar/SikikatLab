using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using SilikatLab.Interfaces;
using SilikatLab.Services;
using SilikatLab.ViewModels;

namespace SilikatLab
{
    /// <summary> Interaction logic for App.xaml </summary>
    public partial class App : Application
    {
        private static IServiceProvider _Services;
        private static IServiceCollection GetServices()
        {
            var services = new ServiceCollection();
            InitializeServices(services);
            return services;
        }
        public static IServiceProvider Services => _Services ??= GetServices().BuildServiceProvider();
        /// <summary> Инит сервисов </summary>
        private static void InitializeServices(IServiceCollection Services)
        {
            Services.AddTransient<IDialogService, WindowDialogService>();

            Services.AddScoped<MainWindowViewModel>();

        }
    }
}
