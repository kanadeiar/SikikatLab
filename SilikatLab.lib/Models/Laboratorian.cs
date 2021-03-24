using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SilikatLab.lib.Models.Base;

namespace SilikatLab.lib.Models
{
    /// <summary> Лаборант </summary>
    public partial class Laboratorian : Entity
    {
        private string _SurName;

        /// <summary> Фамилия </summary>
        [Required, MaxLength(60)]
        public string SurName
        {
            get => _SurName;
            set => Set(ref _SurName, value);
        }

        private string _Name;

        /// <summary> Имя </summary>
        [Required, MaxLength(60)]
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        private string _Patronymic;

        /// <summary> Отчество </summary>
        [Required, MaxLength(60)]
        public string Patronymic
        {
            get => _Patronymic;
            set => Set(ref _Patronymic, value);
        }

        private bool _Inactive;

        /// <summary> Лаборант неактивен, находится в архиве </summary>
        public bool Inactive   
        {
            get => _Inactive;
            set => Set(ref _Inactive, value);
        }

        /// <summary> Исследования </summary>
        public virtual IEnumerable<Research> Researches { get; set; } = new List<Research>();
    }
}
