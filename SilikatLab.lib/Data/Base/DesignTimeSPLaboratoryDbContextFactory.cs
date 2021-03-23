using Microsoft.EntityFrameworkCore.Design;

namespace SilikatLab.lib.Data.Base
{
    class DesignTimeSPLaboratoryDbContextFactory : IDesignTimeDbContextFactory<SPLaboratoryEntities>
    {
        public SPLaboratoryEntities CreateDbContext(string[] args)
        {
            return new();
        }
    }
}
