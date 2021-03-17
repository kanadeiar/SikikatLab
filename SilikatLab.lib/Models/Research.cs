using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using SilikatLab.lib.Models.Base;

namespace SilikatLab.lib.Models
{
    /// <summary> Результат исследования </summary>
    public class Research : Entity
    {
        private DateTime _DateTime;

        /// <summary> Датавремя результата </summary>
        [Required]
        public DateTime DateTime
        {
            get => _DateTime;
            set => Set(ref _DateTime, value);
        }

        private string _Name;

        /// <summary> Название </summary>
        [Required, MaxLength(200)]
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        private double _Value;

        /// <summary> Значение исследования </summary>
        public double Value
        {
            get => _Value;
            set => Set(ref _Value, value);
        }

        private string _Text;

        /// <summary> Текст исследования </summary>
        [MaxLength(300)]
        public string Text
        {
            get => _Text;
            set => Set(ref _Text, value);
        }

        private string _Description;

        /// <summary> Примечание </summary>
        [MaxLength(300)]
        public string Description
        {
            get => _Description;
            set => Set(ref _Description, value);
        }

        /// <summary> Задание </summary>
        [Required]
        public virtual WorkTask WorkTask { get; set; }

        /// <summary> Лаборант </summary>
        [Required]
        public virtual Laboratorian Laboratorian { get; set; }

        /// <summary> Рабочая смена </summary>
        [Required]
        public virtual WorkShift WorkShift { get; set; }
    }
}
