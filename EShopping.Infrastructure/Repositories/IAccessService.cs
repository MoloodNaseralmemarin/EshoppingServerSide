using DataLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Infrastructure.Repositories
{
    public interface IAccessService
    {
        Task<List<UserModel>> GetAllUsers();
    }
}
