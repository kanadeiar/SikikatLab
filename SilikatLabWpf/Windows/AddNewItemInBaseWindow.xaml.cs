using System;
using System.Windows;
using SilikatLabWpf.Models;

namespace SilikatLabWpf.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewItemInBaseWindow.xaml
    /// </summary>
    public partial class AddNewItemInBaseWindow : Window
    {
        public TestResult TestResult { get; set; }
        public AddNewItemInBaseWindow()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!DateTime.TryParse(TextBoxDate.Text, out var date))
            {
                MessageBox.Show("Неверно введена дата!");
                return;
            }
            if (!double.TryParse(TextBoxValue.Text, out var value))
            {
                MessageBox.Show("Неверно введено значение результата");
                return;
            }

            TestResult = new TestResult
            {
                DateTime = date,
                ResearchName = TextBoxNameReseasch.Text,
                ObjectName = TextBoxObject.Text,
                WorkShiftName = TextBoxShift.Text,
                Name = TextBoxName.Text,
                Value = value,
                Result = TextBoxResult.Text,
                Description = TextBoxDescription.Text,
            };
            this.DialogResult = true;
            Close();
        }
    }
}
