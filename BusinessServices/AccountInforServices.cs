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
   public class AccountInforServices: IAccountInforServices
    {

       private readonly UnitOfWork _unitOfWork;

       public AccountInforServices()
       {
           _unitOfWork = new UnitOfWork();
       }

        public BusinessEntities.AccountInfoEntity GetAccountInfoById(int AccountInfoId)
        {
            var accountInfo = _unitOfWork.AccountInfoRepository.GetById(AccountInfoId);
            if (accountInfo != null)
            {
                var accountInfoModel = Mapper.Map<AccountInfo, AccountInfoEntity>(accountInfo);
                return accountInfoModel;
            }
            return null;
        }

        public IEnumerable<BusinessEntities.AccountInfoEntity> GetAllAccountInfo()
        {
            var accountInfo = _unitOfWork.AccountInfoRepository.GetAll();
            if (accountInfo.Any())
            {
                var accountInfoModel = Mapper.Map<IEnumerable<AccountInfo>, IEnumerable<AccountInfoEntity>>(accountInfo);
                return accountInfoModel;
            }
            return null;
        }

        public int CreateAccountInfo(BusinessEntities.AccountInfoEntity AccountInfoEntity)
        {
            using (var scope = new TransactionScope())
            {
                var accountInfoModel = Mapper.Map<AccountInfoEntity, AccountInfo>(AccountInfoEntity);
                _unitOfWork.AccountInfoRepository.Insert(accountInfoModel);
                _unitOfWork.Save();
                scope.Complete();
                return accountInfoModel.Id;
            }
        }

        public bool UpdateAccountInfo(BusinessEntities.AccountInfoEntity AccountInfoEntity)
        {
            var success = false;
            if (AccountInfoEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var accountInfo = Mapper.Map<AccountInfoEntity, AccountInfo>(AccountInfoEntity);
                    _unitOfWork.AccountInfoRepository.Update(accountInfo);
                    _unitOfWork.Save();
                    scope.Complete();
                    success = true;
                }
            }
            return success;
        }

        public bool DeleteAccountInfo(int AccountInfoId)
        {
            var success = false;
            if (AccountInfoId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var AccountInfo = _unitOfWork.AccountInfoRepository.GetById(AccountInfoId);
                    if (AccountInfo != null)
                    {
                        _unitOfWork.AccountInfoRepository.Delete(AccountInfo);
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
