using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SilikatLab.lib.Models.Base;

namespace SilikatLab.lib.Models
{
    /// <summary> Задание </summary>
    public class WorkTask : Entity
    {
        private DateTime _DateTime;

        /// <summary> Датавремя создания задания </summary>
        [Required]
        public DateTime DateTime
        {
            get => _DateTime;
            set => Set(ref _DateTime, value);
        }

        private DateTime _TaskDateTime;

        /// <summary> Датавремя начала выполнения задания </summary>
        [Required]
        public DateTime TaskDateTime
        {
            get => _TaskDateTime;
            set => Set(ref _TaskDateTime, value);
        }

        private string _Name;

        /// <summary> Название </summary>
        [Required, MaxLength(200)]
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        private int _AgainInMinutes;

        /// <summary> Повтор задания, минуты </summary>
        public int AgainInMinutes
        {
            get => _AgainInMinutes;
            set => Set(ref _AgainInMinutes, value);
        }

        /// <summary> Вид исследования </summary>
        public virtual TypeResearch TypeResearch { get; set; }

        /// <summary> Объект исследования </summary>
        public virtual ResearchObject ResearchObject { get; set; }

        /// <summary> Результаты исследования </summary>
        public IEnumerable<Research> ResearchResults { get; set; } = new List<Research>();

    }
}
