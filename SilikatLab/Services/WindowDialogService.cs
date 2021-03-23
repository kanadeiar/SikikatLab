using System;
using System.Windows;
using SilikatLab.lib.Interfaces;

namespace SilikatLab.Services
{
    class WindowDialogService : IDialogService
    {
        public void ShowInfo(string message) => MessageBox.Show(message);
    }
}
