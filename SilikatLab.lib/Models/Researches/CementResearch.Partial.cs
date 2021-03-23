namespace SilikatLab.lib.Models.Researches
{
    public partial class CementResearch
    {
        public override string ToString() => base.ToString() +
                                             $" № партии: {Party} Паспорт: {PassportVc} {PassportKsh} {PassportNsh} факт: {ActualVc} {ActualKsh} {ActualNsh} Откуда: {FromName}";
    }
}