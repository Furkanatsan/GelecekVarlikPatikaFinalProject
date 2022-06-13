using Apmasy.Entity.Dto.DtoUser;
using Apmasy.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Dal.Abstract
{
    public interface IUserRepository
    {
        User Login(User loginUser);

        User InsertUser(User item);

        User UpdateUser(User item );
        List<User> GetListUser();
        
        User GetByIdUser(int id);
        bool DeleteUser(int id);

        bool DeleteUser(User item);
    }
}
