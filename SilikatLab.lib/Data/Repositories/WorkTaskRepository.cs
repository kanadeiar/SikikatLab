using System.Collections.Generic;
using System.Linq;
using SilikatLab.lib.Data.Base;
using SilikatLab.lib.Models;

namespace SilikatLab.lib.Data.Repositories
{
    public class WorkTaskRepository : BaseRepository<WorkTask>
    {
        public new IEnumerable<WorkTask> GetAll() => Context.WorkTasks.OrderBy(t => t.DateTime);
        public WorkTaskRepository(SPLaboratoryEntities laboratoryEntities) : base(laboratoryEntities)
        {
        }
    }
}
