using SilikatLab.lib.Data.Base;
using SilikatLab.lib.Models;

namespace SilikatLab.lib.Data.Repositories
{
    public class ResearchObjectRepository : BaseRepository<ResearchObject>
    {
        public ResearchObjectRepository(SPLaboratoryEntities laboratoryEntities) : base(laboratoryEntities)
        {
        }
    }
}
