using System.Windows;

namespace SilikatLabWpf.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewTaskWindow.xaml
    /// </summary>
    public partial class AddNewTaskWindow : Window
    {
        public AddNewTaskWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
