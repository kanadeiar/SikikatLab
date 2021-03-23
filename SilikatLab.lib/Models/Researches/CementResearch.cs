using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SilikatLab.lib.Models.Researches
{
    /// <summary> Результат исследования по цементу </summary>
    [Table("CementResearch")]
    public partial class CementResearch : Research
    {
        private string _Party;

        /// <summary> Номер партии </summary>
        [Required]
        public string Party
        {
            get => _Party;
            set => Set(ref _Party, value);
        }

        private float _PassportVc;

        /// <summary> Паспорт В/ц </summary>
        [Required]
        public float PassportVc
        {
            get => _PassportVc;
            set => Set(ref _PassportVc, value);
        }

        private float _PassportNsh;

        /// <summary> Паспорт н/сх </summary>
        [Required]
        public float PassportNsh
        {
            get => _PassportNsh;
            set => Set(ref _PassportNsh, value);
        }

        private float _PassportKsh;

        /// <summary> Паспорт к/сх </summary>
        [Required]
        public float PassportKsh
        {
            get => _PassportKsh;
            set => Set(ref _PassportKsh, value);
        }

        private float _ActualVc;

        /// <summary> Фактическое В/ц </summary>
        [Required]
        public float ActualVc
        {
            get => _ActualVc;
            set => Set(ref _ActualVc, value);
        }

        private float _ActualNsh;

        /// <summary> Фактическое н/сх </summary>
        [Required]
        public float ActualNsh
        {
            get => _ActualNsh;
            set => Set(ref _ActualNsh, value);
        }

        private float _ActualKsh;

        /// <summary> Фактическое к/сх </summary>
        [Required]
        public float ActualKsh
        {
            get => _ActualKsh;
            set => Set(ref _ActualKsh, value);
        }

        private string _FromName;

        /// <summary> Откуда </summary>
        [MaxLength(200), Required]
        public string FromName
        {
            get => _FromName;
            set => Set(ref _FromName, value);
        }
    }
}
