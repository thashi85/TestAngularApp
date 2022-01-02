using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.DBAccess.Common;
using TestApp.Domain.Interfaces;
using TestApp.Domain.TestDBContext;
using TestApp.Domain.User;

namespace TestApp.DBAccess
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SampleDBContext context) : base(context)
        {
        }
        public new IEnumerable<User> GetAll()
        {
            var t = _context.Users.Include(m => m.UserGroup).ToList();
            return t;
        }
    }

}
