using System.Windows;
using SilikatLab.lib.Models;

namespace SilikatLab.Windows
{
    /// <summary>
    /// Логика взаимодействия для ShowViewResearchWindow.xaml
    /// </summary>
    public partial class ShowViewResearchWindow : Window
    {
        public string LocTitle { get; set; } = "Просмотр данных результатов простого исследования";

        public static readonly DependencyProperty ResearchProperty = DependencyProperty.Register(
            nameof(Research), typeof(Research), typeof(ShowViewResearchWindow), new PropertyMetadata(default(Research)));

        public Research Research
        {
            get => (Research) GetValue(ResearchProperty);
            set => SetValue(ResearchProperty, value);
        }

        public ShowViewResearchWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
