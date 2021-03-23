using System.Collections.Generic;
using System.Linq;
using SilikatLab.lib.Data.Base;
using SilikatLab.lib.Models;

namespace SilikatLab.lib.Data.Repositories
{
    public class LaboratorianRepository : BaseRepository<Laboratorian>
    {
        public new IEnumerable<Laboratorian> GetAll() => Context.Laboratorians.OrderBy(l => l.SurName);
        public LaboratorianRepository(SPLaboratoryEntities laboratoryEntities) : base(laboratoryEntities)
        {
        }
    }
}
