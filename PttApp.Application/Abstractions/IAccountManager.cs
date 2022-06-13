using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PttApp.Domain.Entities;

namespace PttApp.Application.Abstractions
{
    public interface IAccountManager
    {
        List<AccountPageItem> GetAccountPageItems();
        List<AccountPageItemLogined> GetAccountPageItemsLogined();
    }
}