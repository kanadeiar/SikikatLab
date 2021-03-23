using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SilikatLab.lib.Models.Researches
{
    /// <summary> Результат исследования по шламу </summary>
    [Table("SludgeResearch")]
    public partial class SludgeResearch : Research
    {
        private float _Density;

        /// <summary> Плотность </summary>
        [Required]
        public float Density
        {
            get => _Density;
            set => Set(ref _Density, value);
        }

        private float _Surface;

        /// <summary> Поверхность </summary>
        [Required]
        public float Surface
        {
            get => _Surface;
            set => Set(ref _Surface, value);
        }

        private float _Sieve0_8;

        /// <summary> Сито 0.8 </summary>
        [Required]
        public float Sieve0_8
        {
            get => _Sieve0_8;
            set => Set(ref _Sieve0_8, value);
        }

        private float _Sieve0_09;

        /// <summary> Сито 0.09 </summary>
        public float Sieve0_09
        {
            get => _Sieve0_09;
            set => Set(ref _Sieve0_09, value);
        }

        private float _Sieve0_045;

        /// <summary> Сито 0.045 </summary>
        public float Sieve0_045
        {
            get => _Sieve0_045;
            set => Set(ref _Sieve0_045, value);
        }

        private float _Gypsum;

        /// <summary> Гипса содержание </summary>
        public float Gypsum
        {
            get => _Gypsum;
            set => Set(ref _Gypsum, value);
        }

        private float _Humidity;

        /// <summary> Влажность массива </summary>
        public float Humidity
        {
            get => _Humidity;
            set => Set(ref _Humidity, value);
        }
    }
}
