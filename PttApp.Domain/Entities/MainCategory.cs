using PttApp.Domain.Entities.Common;
using Xamarin.Forms;

namespace PttApp.Domain.Entities
{
    public class MainCategory : BaseEntity
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
    }
}