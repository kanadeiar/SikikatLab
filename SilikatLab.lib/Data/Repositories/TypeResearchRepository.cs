using SilikatLab.lib.Data.Base;
using SilikatLab.lib.Models;

namespace SilikatLab.lib.Data.Repositories
{
    public class TypeResearchRepository : BaseRepository<TypeResearch>
    {
        public TypeResearchRepository(SPLaboratoryEntities laboratoryEntities) : base(laboratoryEntities)
        {
        }
    }
}
