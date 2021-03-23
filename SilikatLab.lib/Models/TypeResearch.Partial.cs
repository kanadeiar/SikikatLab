using System.ComponentModel.DataAnnotations.Schema;

namespace SilikatLab.lib.Models
{
    public partial class TypeResearch
    {
        public override string ToString() => $"{Name}";

        /// <summary> Полное наименование </summary>
        public string FullName => $"{Name}, {TypeResultString}";

        /// <summary> Название типа вида иссследования </summary>
        [NotMapped]
        public string TypeResultString =>
            (TypeResult) switch
            {
                IsTypeResult.Simple => "Простое",
                IsTypeResult.BlockQualityResearch => "Качество блоков",
                IsTypeResult.SludgeResearch => "Шлам",
                IsTypeResult.CementReseatch => "Цемент",
                IsTypeResult.HammerBinderResearch => "Молото-вяжущее",
                _ => "Неизвестный",
            };
    }
}
