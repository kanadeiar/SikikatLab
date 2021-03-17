using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SilikatLab.lib.Models.Base;

namespace SilikatLab.lib.Models
{
    /// <summary> Объект исследования </summary>
    public class ResearchObject : Entity
    {
        private string _Name;

        /// <summary> Название </summary>
        [Required, MaxLength(160)]
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        /// <summary> Задания </summary>
        public virtual IEnumerable<WorkTask> WorkTasks { get; set; } = new List<WorkTask>();
    }
}
