using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SilikatLabWpf.Data;
using SilikatLabWpf.Models;
using SilikatLabWpf.Windows;


namespace SilikatLabWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DbContextOptions<LaboratorianDb> _options;
        private ObservableCollection<TestResult> testResults;
        private static Random rnd = new Random();
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

        private void ButtonReportInExcel_OnClick(object sender, RoutedEventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var finfo = new FileInfo(Path.Combine( Environment.CurrentDirectory, "TemplateSvod.xlsx"));
            using ExcelPackage excel = new ExcelPackage(finfo);
            var worksheet = excel.Workbook.Worksheets[0];
            var i = 0;
            worksheet.Cells[3, 1].Value = "01.01.2021";
            worksheet.Cells[4, ++i].Value = "1-я смена";
            worksheet.Cells[4, ++i].Value = 84.19;
            worksheet.Cells[4, ++i].Value = 85;
            worksheet.Cells[4, ++i].Value = 20.3;
            worksheet.Cells[4, ++i].Value = 663.44;
            worksheet.Cells[4, ++i].Value = 89.0;
            worksheet.Cells[4, ++i].Value = 100;
            worksheet.Cells[4, ++i].Value = 2.2;
            worksheet.Cells[4, ++i].Value = 657.44;
            worksheet.Cells[4, ++i].Value = 1.15;
            worksheet.Cells[4, ++i].Value = 640.94;
            worksheet.Cells[4, ++i].Value = 506.4;
            worksheet.Cells[4, ++i].Value = 2980.1;
            worksheet.Cells[4, ++i].Value = 21.04;
            worksheet.Cells[4, ++i].Value = 38.1;
            worksheet.Cells[4, ++i].Value = 506.4;
            worksheet.Cells[4, ++i].Value = 2980.1;
            worksheet.Cells[4, ++i].Value = 21.04;
            worksheet.Cells[4, ++i].Value = 38.1;
            worksheet.Cells[4, ++i].Value = 38.1;
            i++;
            worksheet.Cells[4, ++i].Value = 38.1;




            var finfoSave = new FileInfo(Path.Combine(Environment.CurrentDirectory, "Test1.xlsx"));
            excel.SaveAs(finfoSave);
            MessageBox.Show("Файл успешно сохранен по пути:\n" + finfoSave.FullName);
        }

        private void MenuItemLaboratoriansEdit_Click(object sender, RoutedEventArgs e)
        {
            var window = new EditLaboratorianWindow(_options) {Owner = this};
            window.ShowDialog();
        }



        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _options = new DbContextOptionsBuilder<LaboratorianDb>().UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Laboratorian.DB").Options;

            await using var db = new LaboratorianDb(_options);
            await InitDbAsync(db);
            testResults = new ObservableCollection<TestResult>(db.TestResults);

            DataGridResults.ItemsSource = testResults;
        }

        private static async Task InitDbAsync(LaboratorianDb db)
        {
            //await db.Database.EnsureDeletedAsync();
            if (await db.Database.EnsureCreatedAsync())
                MessageBox.Show("База данных создана заново и заполнена тестовыми данными!");

            if (await db.Laboratorians.AnyAsync() == false)
            {
                var laboratorians = Enumerable.Range(1, 2).Select(l => new Laboratorian
                {
                    SurName = $"Иванов{l}",
                    Name = $"Иван{l}",
                    Patronymic = $"Иванович{l}",
                }).ToArray();
                await db.Laboratorians.AddRangeAsync(laboratorians);
                await db.SaveChangesAsync();
            }
            if (await db.TestResults.AnyAsync() == false)
            {
                var testResults = Enumerable.Range(1, 2).Select(r => new TestResult
                {
                    DateTime = DateTime.Now.AddMinutes(- rnd.Next(920)),
                    ResearchName = $"Исследование № {r}",
                    ObjectName = $"Массив № {r}",
                    WorkShiftName = $"Смена № {r}",
                    Name = $"Плотность",
                    Value = rnd.NextDouble() * 100.0,
                    Result = $"Результаты исследования - 0",
                    Description = $"Описание {r}",
                }).ToArray();
                await db.TestResults.AddRangeAsync(testResults);
                await db.SaveChangesAsync();
            }
        }


        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            testResults.Clear();
            await using var db = new LaboratorianDb(_options);
            foreach (var res in db.TestResults)
            {
                testResults.Add(res);
            }
        }

        private void AddNewItemInBase_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
