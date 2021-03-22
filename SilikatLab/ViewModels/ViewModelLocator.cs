using Microsoft.Extensions.DependencyInjection;

namespace SilikatLab.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Services
            .GetRequiredService<MainWindowViewModel>();
    }
}
