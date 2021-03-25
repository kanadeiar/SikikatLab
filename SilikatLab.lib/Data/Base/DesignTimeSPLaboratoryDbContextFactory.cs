using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SilikatLab.lib.Data.Base
{
    class DesignTimeSPLaboratoryDbContextFactory : IDesignTimeDbContextFactory<SPLaboratoryEntities>
    {
        public SPLaboratoryEntities CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<SPLaboratoryEntities>()
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SPLaboratoryDev.DB").Options;
            return new(options);
        }
    }
}
