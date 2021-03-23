using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SilikatLab.lib.Models
{
    public partial class WorkTask
    {
        /// <summary> Повтор в строке </summary>
        [NotMapped]
        public string AgainText => (AgainInMinutes != 0) ? $"повтор через {AgainInMinutes} минут" : default;
        /// <summary> Завершено ли задание в строке </summary>
        [NotMapped]
        public string CompletedString => (Completed) ? "Выполнено" : "Не выполнено";
        public override string ToString() =>
            $"{DateTime} {Name} выполнить: {TaskDateTime}, {AgainText} {CompletedString} вид: {TypeResearch.FullName} объект: {ResearchObject.Name}";
        /// <summary> Повтор задания по истечению времени </summary>
        public void ReAgain()
        {
            if (AgainInMinutes == 0 || TaskDateTime >= DateTime.Now) return;
            while (DateTime.Now > TaskDateTime)
                TaskDateTime = TaskDateTime.AddMinutes(AgainInMinutes);
        }
    }
}