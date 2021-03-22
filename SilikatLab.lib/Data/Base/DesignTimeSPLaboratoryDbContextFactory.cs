using Microsoft.EntityFrameworkCore.Design;

namespace SilikatLab.lib.Data.Base
{
    class DesignTimeSPLaboratoryDbContextFactory : IDesignTimeDbContextFactory<SPLaboratoryDb>
    {
        public SPLaboratoryDb CreateDbContext(string[] args)
        {
            return new();
        }
    }
}
