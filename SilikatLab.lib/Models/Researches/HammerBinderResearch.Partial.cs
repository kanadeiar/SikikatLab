namespace SilikatLab.lib.Models.Researches
{
    public partial class HammerBinderResearch
    {
        public override string ToString() => base.ToString() +
                                             $" остаток на сите: {Sieve0_2} поверхность: {Surface} производительность: {Perfomance} активность: {Activity}";
    }
}