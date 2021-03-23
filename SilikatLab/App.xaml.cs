using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using SilikatLab.lib.Data.Base;
using SilikatLab.lib.Data.Repositories;
using SilikatLab.lib.Interfaces;
using SilikatLab.lib.Models;
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
            Services.AddDbContext<SPLaboratoryEntities>();
            Services.AddSingleton<IRepository<Laboratorian>, LaboratorianRepository>();
            Services.AddSingleton<IRepository<ResearchObject>, ResearchObjectRepository>();
            Services.AddSingleton<IRepository<TypeResearch>, TypeResearchRepository>();
            Services.AddSingleton<IRepository<UserLogin>, UserLoginRepository>();
            Services.AddSingleton<IRepository<WorkShift>, WorkShiftRepository>();
            Services.AddSingleton<IRepository<WorkTask>, WorkTaskRepository>();

            Services.AddSingleton<IRepository<Research>, ResearchRepository>();

            Services.AddTransient<IDialogService, WindowDialogService>();

            Services.AddSingleton<MainWindowViewModel>();

        }
    }
}
