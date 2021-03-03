using System.Windows;
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
            var window = new DetailsResultWindow();
            window.Owner = this;
            window.ShowDialog();
        }
    }
}
