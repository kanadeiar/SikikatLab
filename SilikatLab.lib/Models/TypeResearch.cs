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
        public virtual IEnumerable<WorkTask> WorkTasks { get; set; }
    }
}
