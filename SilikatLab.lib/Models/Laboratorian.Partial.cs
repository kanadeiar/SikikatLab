using System.ComponentModel.DataAnnotations.Schema;

namespace SilikatLab.lib.Models
{
    public partial class Laboratorian
    {
        public override string ToString()
        {
            return $"{SurName} {Name} {Patronymic}";
        }
        [NotMapped] public string FullName => $"{SurName} {Name} {Patronymic}";
    }
}
