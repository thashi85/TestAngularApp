using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Interfaces;
using TestApp.Domain.TestDBContext;

namespace TestApp.DBAccess.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SampleDBContext _context;

        public UnitOfWork(SampleDBContext context)
        {
            _context = context;    
            Users = new UserRepository(_context);
            UserGroups = new UserGroupRepository(_context);
            AccessRules = new AccessRuleRepository(_context);
        }
       
        public IUserRepository Users { get; private set; }

        public IUserGroupRepository UserGroups { get; private set; }

        public IAccessRuleRepository AccessRules { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
