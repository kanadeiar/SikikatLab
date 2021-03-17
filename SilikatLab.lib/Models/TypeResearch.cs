using System.Collections;
using System.Collections.Generic;
using SilikatLab.lib.Models.Base;

namespace SilikatLab.lib.Models
{
    /// <summary> Вид исследования </summary>
    public class TypeResearch : Entity
    {
        private string _Name;

        /// <summary> Название </summary>
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        /// <summary> Задания </summary>
        public virtual IEnumerable<WorkTask> WorkTasks { get; set; } = new List<WorkTask>();

        private IsTypeResult _isTypeResult;

        /// <summary> Тип результата исследования </summary>
        public IsTypeResult TypeResult
        {
            get => _isTypeResult;
            set => Set(ref _isTypeResult, value);
        }

        public enum IsTypeResult
        {
            Simple = 0, //одна цифра и текст-описание
        }
    }
}
