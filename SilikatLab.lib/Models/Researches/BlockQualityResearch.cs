using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SilikatLab.lib.Models.Researches
{
    /// <summary> Результат исследования по качеству блоков </summary>
    [Table("BlockQualityReearches")]
    public class BlockQualityResearch : Research
    {
        private string _Format;

        /// <summary> Формат </summary>
        [MaxLength(60), Required]
        public string Format
        {
            get => _Format;
            set => Set(ref _Format, value);
        }

        private string _Trademark;

        /// <summary> Марка </summary>
        [MaxLength(100), Required]
        public string Trademark
        {
            get => _Trademark;
            set => Set(ref _Trademark, value);
        }

        private float _Weight;

        /// <summary> Масса образца </summary>
        [Required]
        public float Weight
        {
            get => _Weight;
            set => Set(ref _Weight, value);
        }

        private float _SizeX;

        /// <summary> Размер X </summary>
        [Required]
        public float SizeX
        {
            get => _SizeX;
            set => Set(ref _SizeX, value);
        }

        private float _SizeY;

        /// <summary> Размер Y </summary>
        [Required]
        public float SizeY
        {
            get => _SizeY;
            set => Set(ref _SizeY, value);
        }

        private float _SizeZ;

        /// <summary> Размер Z </summary>
        [Required]
        public float SizeZ
        {
            get => _SizeZ;
            set => Set(ref _SizeZ, value);
        }

        private float _BeforeDensity;

        /// <summary> Плотность сырая </summary>
        [Required]
        public float BeforeDensity
        {
            get => _BeforeDensity;
            set => Set(ref _BeforeDensity, value);
        }

        private float _Coefficient;

        /// <summary> Коэффициент </summary>
        [Required]
        public float Coefficient
        {
            get => _Coefficient;
            set => Set(ref _Coefficient, value);
        }

        private float _BeforeWeight;

        /// <summary> Масса сырая </summary>
        [Required]
        public float BeforeWeight
        {
            get => _BeforeWeight;
            set => Set(ref _BeforeWeight, value);
        }

        private float _AfterWeight;

        /// <summary> Масса сушеная </summary>
        public float AfterWeight
        {
            get => _AfterWeight;
            set => Set(ref _AfterWeight, value);
        }

        private float _Humidity;

        /// <summary> Влажность </summary>
        public float Humidity
        {
            get => _Humidity;
            set => Set(ref _Humidity, value);
        }

        private float _Load;

        /// <summary> Нагрузка </summary>
        [Required]
        public float Load
        {
            get => _Load;
            set => Set(ref _Load, value);
        }

        private float _Strength;

        /// <summary> Прочность </summary>
        [Required]
        public float Strength
        {
            get => _Strength;
            set => Set(ref _Strength, value);
        }

        private float _AfterDensity;

        /// <summary> Плотность сушеная </summary>
        public float AfterDensity
        {
            get => _AfterDensity;
            set => Set(ref _AfterDensity, value);
        }
    }
}
