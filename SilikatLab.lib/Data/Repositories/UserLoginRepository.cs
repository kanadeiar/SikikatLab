using SilikatLab.lib.Data.Base;
using SilikatLab.lib.Models;

namespace SilikatLab.lib.Data.Repositories
{
    public class UserLoginRepository : BaseRepository<UserLogin>
    {
        public UserLoginRepository(SPLaboratoryEntities laboratoryEntities) : base(laboratoryEntities)
        {
        }
    }
}
