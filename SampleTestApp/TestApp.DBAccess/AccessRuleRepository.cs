using TestApp.DBAccess.Common;
using TestApp.Domain.Interfaces;
using TestApp.Domain.TestDBContext;
using TestApp.Domain.UserGroup;

namespace TestApp.DBAccess
{
    public class AccessRuleRepository : GenericRepository<AccessRule>, IAccessRuleRepository
    {
        public AccessRuleRepository(SampleDBContext context) : base(context)
        {
        }
    }

}
