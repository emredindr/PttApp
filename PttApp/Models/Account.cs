using System;
using System.Collections.Generic;
using System.Text;
using PttApp.Application.Abstractions;
using PttApp.Domain.Entities;

namespace PttApp.Models
{
    public class Account
    {
        public List<AccountPageItem> AllAccountPageItems { get; set; }
        public List<AccountPageItemLogined> AllAccountPageItemsLogined { get; set; }
        public Account(IAccountManager accountManager)
        {
            AllAccountPageItems = accountManager.GetAccountPageItems();
            AllAccountPageItemsLogined = accountManager.GetAccountPageItemsLogined();
        }
    }
}
