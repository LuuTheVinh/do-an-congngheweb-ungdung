using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    public interface IAccountInforServices
    {
        AccountInfoEntity GetAccountInfoById(int AccountInfoId);
        IEnumerable<AccountInfoEntity> GetAllAccountInfo();
        int CreateAccountInfo(AccountInfoEntity AccountInfoEntity);
        bool UpdateAccountInfo(AccountInfoEntity AccountInfoEntity);
        bool DeleteAccountInfo(int AccountInfoId);
    }
}
