using System.ComponentModel.DataAnnotations.Schema;

namespace SilikatLab.lib.Models
{
    public partial class Research
    {
        public override string ToString() => $"{DateTime} {Name} результаты: {ResultString} вид: {TypeResearch.FullName} объект: {ResearchObject.Name} лаборант: {Laboratorian.FullName} смена: {WorkShift.Name} задание: {WorkTaskString}";
        
        /// <summary> Норма в строке </summary>
        [NotMapped]
        public string NormalString => (Normal) ? "Отлично" : "Плохо";
        /// <summary> Результаты в строке </summary>
        [NotMapped]
        public string ResultString => $"{Value:F2} {Text} {NormalString}";
        /// <summary> Задание этого результата в строке </summary>
        [NotMapped]
        public string WorkTaskString
        {
            get
            {
                if (WorkTask is null)
                    return default;
                return WorkTask.ToString();
            }
        }
    }
}