using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domain.Interfaces
{
    public interface IUserRepository: IGenericRepository<User.User>
    {
        //User specific additional methods goes here
    }
}
