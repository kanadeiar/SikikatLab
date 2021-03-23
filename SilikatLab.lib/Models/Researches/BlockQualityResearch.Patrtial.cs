namespace SilikatLab.lib.Models.Researches
{
    public partial class BlockQualityResearch
    {
        public override string ToString() => base.ToString() +
                                             $" {Trademark} {Format} вес: {Weight} размеры: {SizeX} {SizeY} {SizeZ} Плотность: {BeforeDensity} {AfterDensity} Масса: {BeforeWeight} {AfterWeight} влажность {Humidity} загрузка {Load} прочность {Strength}";
    }
}