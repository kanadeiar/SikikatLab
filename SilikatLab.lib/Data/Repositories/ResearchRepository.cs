using System.Collections.Generic;
using System.Linq;
using SilikatLab.lib.Data.Base;
using SilikatLab.lib.Models;

namespace SilikatLab.lib.Data.Repositories
{
    public class ResearchRepository : BaseRepository<Research>
    {
        public new IEnumerable<Research> GetAll() => Context.Researches.OrderBy(r => r.DateTime);
        public ResearchRepository(SPLaboratoryEntities laboratoryEntities) : base(laboratoryEntities)
        {
        }
    }
}
