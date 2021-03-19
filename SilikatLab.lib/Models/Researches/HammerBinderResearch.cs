using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SilikatLab.lib.Models.Researches
{
    /// <summary> Молото-вяжущее исследование </summary>
    [Table("HammerBinderResearch")]
    public class HammerBinderResearch : Research
    {
        private float _Sieve0_2;

        /// <summary> Остаток на сите 0_2 </summary>
        public float Sieve0_2
        {
            get => _Sieve0_2;
            set => Set(ref _Sieve0_2, value);
        }

        private float _Surface;

        /// <summary> Поверхность </summary>
        public float Surface
        {
            get => _Surface;
            set => Set(ref _Surface, value);
        }

        private float _Perfomance;

        /// <summary> Производительность </summary>
        public float Perfomance
        {
            get => _Perfomance;
            set => Set(ref _Perfomance, value);
        }

        private float _Activity;

        /// <summary> Активность </summary>
        [Required]
        public float Activity
        {
            get => _Activity;
            set => Set(ref _Activity, value);
        }
    }
}
