using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
   public interface IUserServices
    {
        UserEntity GetUserEntityById(int UserId);
        IEnumerable<UserEntity> GetAllUsers();
        int CreateUser(UserEntity UserEntity);
        bool UpdateUser(UserEntity UserEntity);
        bool DeleteUser(int UserId);

    }
}
