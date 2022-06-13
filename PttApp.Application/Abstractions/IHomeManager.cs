using System.Collections.Generic;
using PttApp.Domain.Entities;

namespace PttApp.Application.Abstractions
{
    public interface IHomeManager
    {
        List<Banner> GetBanners();
    }
}