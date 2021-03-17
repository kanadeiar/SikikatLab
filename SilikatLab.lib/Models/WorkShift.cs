using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SilikatLab.lib.Models.Base;

namespace SilikatLab.lib.Models
{
    /// <summary> Смена </summary>
    public class WorkShift : Entity
    {
        private string _Name;

        /// <summary> Название </summary>
        [Required, MaxLength(40)]
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        /// <summary> Исследования этой смены </summary>
        public virtual IEnumerable<Research> Researches { get; set; } = new List<Research>();
    }
}
