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
            /// <summary> Простое исследование - цифра и текст </summary>
            Simple = 0, 
            /// <summary> Контроль качества блоков </summary>
            BlockQualityResearch, 
            /// <summary> Исследование шлама </summary>
            SludgeResearch, 
            /// <summary> Исследование цемента </summary>
            CementReseatch, 
            /// <summary> Исследование молото-вяжущего </summary>
            HammerBinderResearch, 
        }
    }
}
