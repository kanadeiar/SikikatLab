using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using SilikatLabWpf.Data;
using SilikatLabWpf.Models;

namespace SilikatLabWpf.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditLaboratorianWindow.xaml
    /// </summary>
    public partial class EditLaboratorianWindow : Window
    {
        private readonly DbContextOptions<LaboratorianDb> _options;
        private ObservableCollection<Laboratorian> laboratorians;
        public EditLaboratorianWindow(DbContextOptions<LaboratorianDb> options)
        {
            InitializeComponent();
            _options = options;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await using var db = new LaboratorianDb(_options);
            laboratorians = new ObservableCollection<Laboratorian>(db.Laboratorians);

            DataGridLaboratorians.ItemsSource = laboratorians;
        }

        private async void Update()
        {
            laboratorians.Clear();
            await using var db = new LaboratorianDb(_options);
            foreach (var l in db.Laboratorians)
                laboratorians.Add(l);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            await using var db = new LaboratorianDb(_options);
            db.Laboratorians.UpdateRange(laboratorians);
            await db.SaveChangesAsync();
        }
    }
}
