using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {                
        IUserRepository Users { get; }
        IUserGroupRepository UserGroups { get; }
        IAccessRuleRepository AccessRules { get; }
        int Complete();
        void Dispose();
    }
}
