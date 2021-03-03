using System.Windows;

namespace SilikatLabWpf.Windows
{
    /// <summary>
    /// Логика взаимодействия для DetailsResultWindow.xaml
    /// </summary>
    public partial class DetailsResultWindow : Window
    {
        public DetailsResultWindow()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
