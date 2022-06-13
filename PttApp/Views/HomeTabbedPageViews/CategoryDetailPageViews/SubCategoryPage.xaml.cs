using PttApp.Application.Abstractions;
using PttApp.Domain.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PttApp.Views.HomeTabbedPageViews.CategoryDetailPageViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubCategoryPage : ContentPage
    {
        readonly private int SelectedMainCategoryId;
        readonly private string SelectedMainCategoryTitle;
        public SubCategoryPage(MainCategory mainCategory)
        {
            InitializeComponent();
            var categoryManager = Startup.ServiceProvider.GetService<ICategoryManager>();
            categoryListView.ItemsSource = categoryManager.GetSubCategories(mainCategory);
            lblName.Text = mainCategory.Title;
            SelectedMainCategoryId = mainCategory.Id;
            SelectedMainCategoryTitle = mainCategory.Title;
        }

        private void OnSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            ListView lstView = (ListView)sender;
            lstView.SelectedItem = null;

            SubCategory selected = (SubCategory)e.SelectedItem;
            if (selected != null && selected.Id > 0)
            {
                Page Page = new SubOfSubCategoryPage(selected);
                Navigation.PushAsync(Page);
            }
        }

        private void SeeAllProduct_Clicked(object sender, System.EventArgs e)
        {
            Page Page = new ProductPage(new ProductFilter { Title = SelectedMainCategoryTitle, MainCategoryId = SelectedMainCategoryId });
            Navigation.PushAsync(Page);
        }
    }
}