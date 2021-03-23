using Microsoft.EntityFrameworkCore;
using SilikatLab.lib.Models;
using SilikatLab.lib.Models.Researches;

namespace SilikatLab.lib.Data.Base
{
    /// <summary> Лабораторная база данных Силикат Плюс </summary>
    public partial class SPLaboratoryEntities : DbContext
    {
        private readonly string _ConnectionString;
        /// <summary> Авторизация пользователей </summary>
        public DbSet<UserLogin> UserLogins { get; set; }
        /// <summary> Лаборанты </summary>
        public DbSet<Laboratorian> Laboratorians { get; set; }
        /// <summary> Объекты исследования </summary>
        public DbSet<ResearchObject> ResearchObjects { get; set; }
        /// <summary> Вид исследования </summary>
        public DbSet<TypeResearch> TypeResearches { get; set; }
        /// <summary> Рабочие смены </summary>
        public DbSet<WorkShift> WorkShifts { get; set; }
        /// <summary> Задания </summary>
        public DbSet<WorkTask> WorkTasks { get; set; }
        /// <summary> Результаты исследования </summary>
        public DbSet<Research> Researches { get; set; }
        /// <summary> Результаты исследования качества блоков </summary>
        public DbSet<BlockQualityResearch> BlockQualityResearches { get; set; }
        /// <summary> Результаты исследования шлама </summary>
        public DbSet<SludgeResearch> SludgeResearches { get; set; }
        /// <summary> Результаты исследования цемента </summary>
        public DbSet<CementResearch> CementResearches { get; set; }
        /// <summary> Результаты исследования молото-вяжущего </summary>
        public DbSet<HammerBinderResearch> HammerBinderResearches { get; set; }
        public SPLaboratoryEntities(string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SPLaboratoryDev.DB")
        {
            _ConnectionString = connectionString;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_ConnectionString);
        }
    }
}
