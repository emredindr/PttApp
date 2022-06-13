using System.Collections.Generic;
using PttApp.Application.Abstractions;
using PttApp.Domain.Entities;

namespace PttApp.Persistence.Managers 
{ 
    public class HomeManager : IHomeManager
    {
        private readonly RestServiceManager<List<Banner>> _restServiceBannerManager;
        public HomeManager()
        {
            _restServiceBannerManager=new RestServiceManager<List<Banner>>();
        }
        public List<Banner> GetBanners()
    {
        return _restServiceBannerManager.GetServiceResponse(ServiceUrlConst.Banner);
    }
  }

}
