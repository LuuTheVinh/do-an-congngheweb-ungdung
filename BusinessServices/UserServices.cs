using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessServices
{
   public class UserServices: IUserServices
    {
       private readonly UnitOfWork _unitOfWork;

       /// <summary>
       /// public Constructor
       /// </summary>
       public UserServices()
       {
           _unitOfWork = new UnitOfWork();
       }

        public BusinessEntities.UserEntity GetUserEntityById(int UserId)
        {
            var User = _unitOfWork.UserRepository.GetById(UserId);
            if (User != null)
            {
                var UserModel = Mapper.Map<User, UserEntity>(User);
                return UserModel;
            }
            return null;
        }

        public IEnumerable<BusinessEntities.UserEntity> GetAllUsers()
        {

            var User = _unitOfWork.UserRepository.GetAll();
            if (User.Any())
            {
                var UserModel = Mapper.Map<IEnumerable<User>, IEnumerable<UserEntity>>(User);
                return UserModel;
            }
            return null;
        }

        public int CreateUser(BusinessEntities.UserEntity UserEntity)
        {
            using (var scope = new TransactionScope())
            {
                var User = Mapper.Map<UserEntity, User>(UserEntity);
                _unitOfWork.UserRepository.Insert(User);
                _unitOfWork.Save();
                scope.Complete();
                return User.Id;
            }
        }

        public bool UpdateUser(BusinessEntities.UserEntity UserEntity)
        {
            var success = false;
            if (UserEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var User = Mapper.Map<UserEntity, User>(UserEntity);
                    _unitOfWork.UserRepository.Update(User);
                    _unitOfWork.Save();
                    scope.Complete();
                    success = true;
                }
            }
            return success;
        }

        public bool DeleteUser(int UserId)
        {
            var success = false;
            if (UserId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var User = _unitOfWork.UserRepository.GetById(UserId);
                    if (User != null)
                    {
                        _unitOfWork.UserRepository.Delete(User);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
