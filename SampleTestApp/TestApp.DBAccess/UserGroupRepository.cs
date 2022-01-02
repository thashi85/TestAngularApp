using TestApp.DBAccess.Common;
using TestApp.Domain.Interfaces;
using TestApp.Domain.TestDBContext;
using TestApp.Domain.UserGroup;

namespace TestApp.DBAccess
{
    public class UserGroupRepository : GenericRepository<UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(SampleDBContext context) : base(context)
        {
        }
    }

}
