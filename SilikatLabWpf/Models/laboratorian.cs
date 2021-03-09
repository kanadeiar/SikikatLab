using System.ComponentModel.DataAnnotations;
using SilikatLabWpf.Models.Base;

namespace SilikatLabWpf.Models
{
    public class Laboratorian : Entity
    {
        [Required, MaxLength(100)]
        public string SurName { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Patronymic { get; set; }
    }
}
