using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SilikatLab.lib.Models.Base;

namespace SilikatLab.lib.Models
{
    /// <summary> Вид исследования </summary>
    public partial class TypeResearch : Entity
    {
        private string _Name;

        /// <summary> Название </summary>
        [Required, MaxLength(200)]
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }


        private IsTypeResult _isTypeResult;

        /// <summary> Тип результата исследования </summary>
        public IsTypeResult TypeResult
        {
            get => _isTypeResult;
            set => Set(ref _isTypeResult, value);
        }

        /// <summary> Задания </summary>
        public virtual IEnumerable<WorkTask> WorkTasks { get; set; } = new List<WorkTask>();

        /// <summary> Исследования с уточнениями </summary>
        public virtual IEnumerable<Research> Researches { get; set; } = new List<Research>();

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