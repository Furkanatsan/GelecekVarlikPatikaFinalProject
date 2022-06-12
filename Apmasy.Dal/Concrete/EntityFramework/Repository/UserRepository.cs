using Apmasy.Dal.Abstract;
using Apmasy.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apmasy.Dal.Concrete.EntityFramework.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context):base(context)//base kalıtım aldığımız yere arguman göndermek için kullanılır.
        {

        }

        public User Login(User loginUser)
        {
            var user = dbset.Where(u => u.Email == loginUser.Email && u.Password == loginUser.Password).SingleOrDefault();
            return user;
        }

        public User InsertUser(User insertUser)
        {
            _context.Entry(insertUser).State = EntityState.Added;
            dbset.Add(insertUser);
            return insertUser;
        }

        public User UpdateUser(User item)
        {
            dbset.Update(item);
            return item;
        }
    }
}
