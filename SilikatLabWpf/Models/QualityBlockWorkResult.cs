namespace SilikatLabWpf.Models
{
    public class QualityBlockWorkResult : WorkResult
    {
        public string Format { get; set; }
        public int NumAutoclave { get; set; }
        public double Weight { get; set; }
        public double SizeX { get; set; }
        public double SizeY { get; set; }
        public double SizeZ { get; set; }
        public double Density { get; set; }
        public double Coefficient { get; set; }
        public double BeforeWeight { get; set; }
        public double AfterWeight { get; set; }
        public double Humidity { get; set; }
        public double Load { get; set; }
        public double Strength { get; set; }
        public double AfterDensity { get; set; }

    }
}