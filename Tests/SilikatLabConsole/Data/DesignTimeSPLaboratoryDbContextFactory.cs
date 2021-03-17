using Microsoft.EntityFrameworkCore.Design;

namespace SilikatLabConsole.Data
{
    class DesignTimeSPLaboratoryDbContextFactory : IDesignTimeDbContextFactory<SPLaboratoryDb>
    {
        public SPLaboratoryDb CreateDbContext(string[] args)
        {
            return new();
        }
    }
}
