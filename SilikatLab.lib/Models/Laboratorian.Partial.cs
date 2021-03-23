using System.ComponentModel.DataAnnotations.Schema;

namespace SilikatLab.lib.Models
{
    public partial class Laboratorian
    {
        public override string ToString() => $"{SurName} {Name} {Patronymic}";
        /// <summary> Полное наименование </summary>
        [NotMapped] public string FullName => $"{SurName} {Name} {Patronymic}";
    }
}
