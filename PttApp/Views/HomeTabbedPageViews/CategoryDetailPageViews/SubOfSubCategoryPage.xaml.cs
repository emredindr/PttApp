using PttApp.Application.Abstractions;
using PttApp.Domain.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PttApp.Views.HomeTabbedPageViews.CategoryDetailPageViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubOfSubCategoryPage : ContentPage
    {
        readonly private int SelectedSubCategoryId;
        readonly private string SelectedSubCategoryTitle;
        readonly private int SelectedMainCategoryId;

        public SubOfSubCategoryPage(SubCategory subCategory)
        {
            InitializeComponent();
            var categoryManager=Startup.ServiceProvider.GetService<ICategoryManager>();
            categoryListView.ItemsSource = categoryManager.GetSubOfSubCategories(subCategory);
            lblName.Text = subCategory.Title;
            SelectedSubCategoryId = subCategory.SubId;
            SelectedSubCategoryTitle = subCategory.Title;
            SelectedMainCategoryId = subCategory.CategoryId;
        }

        private void OnSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            ListView lstView = (ListView)sender;
            lstView.SelectedItem = null;

            SubOfSubCategory selected = (SubOfSubCategory)e.SelectedItem;
            if (selected != null && selected.Id > 0)
            {
                Page Page = new ProductPage(
                    new ProductFilter
                    {
                        Title = selected.Title,
                        MainCategoryId = selected.CategoryId,
                        SubCategoryId = selected.SubCategoryId,
                        SubOfSubCategoryId = selected.SubOfSubId
                    });
                Navigation.PushAsync(Page);
            }

        }
        private void SeeAllProduct_Clicked(object sender, System.EventArgs e)
        {
            Page page = new ProductPage(new ProductFilter {Title = SelectedSubCategoryTitle,SubCategoryId=SelectedSubCategoryId, MainCategoryId = SelectedMainCategoryId });
            Navigation.PushAsync(page);
        }
    }
}