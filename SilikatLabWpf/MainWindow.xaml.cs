using System.Windows;
using System.Windows.Controls;
using SilikatLabWpf.Models;
using SilikatLabWpf.Windows;

namespace SilikatLabWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonNewTask_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddNewTaskWindow();
            window.Owner = this;
            window.ShowDialog();
        }

        private void ButtonDetailsShow_Click(object sender, RoutedEventArgs e)
        {
            var element = ((Button) sender).DataContext as WorkResult;
            if (element is QualityBlockWorkResult qualityBlock)
            {
                var window = new DetailsQualityResultWindow {Owner = this};
                window.ShowDialog();
            }
            else
            {
                var window = new DetailsResultWindow {Owner = this};
                window.ShowDialog();
            }
        }

        private void ButtonAddNewDetailsResult_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddNewResultWindow();
            window.Owner = this;
            window.ShowDialog();
        }

        private void MenuItemAuth_OnClick(object sender, RoutedEventArgs e)
        {
            TabItemEditData.Visibility = Visibility.Visible;
        }

        private void MenuItemDeauth_OnClick(object sender, RoutedEventArgs e)
        {
            TabItemEditData.Visibility = Visibility.Collapsed;
            TabItemShow.IsSelected = true;
        }
    }
}
