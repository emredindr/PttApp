using System.Collections.Generic;
using PttApp.Application.Abstractions;
using PttApp.Domain.Entities;

namespace PttApp.Persistence.Managers
{
    public class AccountManager : IAccountManager
    {
        private readonly RestServiceManager<List<AccountPageItem>> _restServiceAccountPageItemManager;
        private readonly RestServiceManager<List<AccountPageItemLogined>> _restServiceAccountPageItemLoginedManager;
        public AccountManager()
        {
            _restServiceAccountPageItemLoginedManager = new RestServiceManager<List<AccountPageItemLogined>>();
            _restServiceAccountPageItemManager = new RestServiceManager<List<AccountPageItem>>();
        }
        public List<AccountPageItem> GetAccountPageItems()
        {

            return _restServiceAccountPageItemManager.GetServiceResponse(ServiceUrlConst.AccountPageItem);

        }

        public List<AccountPageItemLogined> GetAccountPageItemsLogined()
        {

            return _restServiceAccountPageItemLoginedManager.GetServiceResponse(ServiceUrlConst.AccountPageItemLogined);
        }
    }
}
