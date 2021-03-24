using System;
using System.Windows;
using SilikatLab.lib.Models;

namespace SilikatLab.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewResearchWindow.xaml
    /// </summary>
    public partial class AddNewResearchWindow : Window
    {
        public TypeResearch TargetTypeResearch { get; set; }
        public ResearchObject TargetResearchObject { get; set; }
        public WorkTask TargetWorkTask { get; set; }
        public Research Research { get; set; }
        public AddNewResearchWindow()
        {
            InitializeComponent();
        }
        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            var workTask = (WorkTask)ComboBoxWorkTask.SelectedItem;
            if (string.Equals("<Отсутствует задание>", workTask.Name, StringComparison.CurrentCultureIgnoreCase))
                workTask = null;
            Research = new Research
            {
                DateTime = DateTime.Parse(TextBoxDate.Text),
                TypeResearch = (TypeResearch) ComboBoxTypeReseasch.SelectedItem,
                ResearchObject = (ResearchObject) ComboBoxObject.SelectedItem,
                WorkShift = (WorkShift) ComboBoxShift.SelectedItem,
                WorkTask = workTask,
                Name = TextBoxName.Text,
                Value = double.Parse(TextBoxValue.Text),
                Text = TextBoxResult.Text,
                Normal = CheckBoxNormal.IsChecked ?? false,
                Description = TextBoxDescription.Text,
                Laboratorian = (Laboratorian) ComboBoxLaboratorian.SelectedItem,
            };
            DialogResult = true;
            Close();
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TextBoxDate.Text = DateTime.Now.ToString("dd.MM.yy HH:mm");
            ComboBoxTypeReseasch.SelectedItem = TargetTypeResearch;
            ComboBoxObject.SelectedItem = TargetResearchObject;
            ComboBoxWorkTask.SelectedItem = TargetWorkTask;
        }
    }
}
