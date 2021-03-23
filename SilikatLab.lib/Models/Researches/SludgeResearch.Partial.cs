namespace SilikatLab.lib.Models.Researches
{
    public partial class SludgeResearch
    {
        public override string ToString() => base.ToString() +
                                             $" плотность: {Density} поверхность {Surface} сито: {Sieve0_8} {Sieve0_09} {Sieve0_045} гипс: {Gypsum} влажность: {Humidity}";
    }
}