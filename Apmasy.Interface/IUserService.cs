using Apmasy.Entity.Dto.DtoUser;
using Apmasy.Entity.IBase;
using Apmasy.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Interface
{
    public interface IUserService:IGenericService<User,DtoViewUser>
    {
        public IResponse<DtoUserLoginResp> Login(DtoUserLoginRequest loginUser);

        IResponse<DtoViewUser> InsertUser(DtoInsertUser insertUser, bool saveChanges = true);

        IResponse<DtoViewUser> UpdateUser(DtoViewUser updateUser, bool saveChanges = true);
    }
}
