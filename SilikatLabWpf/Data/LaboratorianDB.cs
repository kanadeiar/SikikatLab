using Microsoft.EntityFrameworkCore;
using SilikatLabWpf.Models;

namespace SilikatLabWpf.Data
{
    public class LaboratorianDb : DbContext
    {
        public DbSet<Laboratorian> Laboratorians { get; set; }
        public DbSet<TestResult> TestResults { get; set; }




        public LaboratorianDb(DbContextOptions<LaboratorianDb> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
