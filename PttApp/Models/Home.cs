using System.Collections.Generic;
using PttApp.Application.Abstractions;
using PttApp.Domain.Entities;

namespace PttApp.Models
{
    public class Home
    {
        public List<Banner> Banners { get; set; }

        public Home(IHomeManager homeManager)
        {
            Banners = homeManager.GetBanners();
        }
    }
}
