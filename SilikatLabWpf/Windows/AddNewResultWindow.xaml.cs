using System.Windows;

namespace SilikatLabWpf.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewResultWindow.xaml
    /// </summary>
    public partial class AddNewResultWindow : Window
    {
        public AddNewResultWindow()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
