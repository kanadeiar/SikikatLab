using System.Collections.Generic;
using System.Linq;
using SilikatLab.lib.Data.Base;
using SilikatLab.lib.Models;

namespace SilikatLab.lib.Data.Repositories
{
    public class WorkShiftRepository : BaseRepository<WorkShift>
    {
        public new IEnumerable<WorkShift> GetAll() => Context.WorkShifts.OrderBy(s => s.Name);
        public WorkShiftRepository(SPLaboratoryEntities laboratoryEntities) : base(laboratoryEntities)
        {
        }
    }
}
