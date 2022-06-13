using System.Collections.Generic;
using PttApp.Domain.Entities;

namespace PttApp.Application.Abstractions
{
    public interface IMyBasketManager
    {
        MyBasketItem Get(int Id);
        int GetAllCount();
        IEnumerable<MyBasketItem> GetAll();
        int Insert(MyBasketItem s);
        int Update(MyBasketItem s);
        int Delete(int Id);

        void Dispose();
    }
}