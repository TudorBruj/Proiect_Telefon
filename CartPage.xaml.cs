namespace Proiect_Telefon;
using Proiect_Telefon.Models;

public partial class CartPage : ContentPage
{
	public CartPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var plist = (ProductList)BindingContext;
        plist.Date = DateTime.UtcNow;
        await App.Database.SaveProductListAsync(plist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var plist = (ProductList)BindingContext;
        await App.Database.DeleteProductListAsync(plist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PaginaProdus((ProductList)
        this.BindingContext)
        {
            BindingContext = new Produs()
        });
    }
    async void OnDeleteButtonItemClicked(object sender, EventArgs e)
    {
        var currentShopList = BindingContext as ProductList;
        var selectedProduct = listView.SelectedItem as Produs;

        if (selectedProduct != null && currentShopList != null)
        {
            await App.Database.DeleteItemFromShopListAsync(selectedProduct.ID, currentShopList.ID);

            listView.ItemsSource = await App.Database.GetListProductsAsync(currentShopList.ID);

            listView.SelectedItem = null;
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var productl = (ProductList)BindingContext;

        listView.ItemsSource = await App.Database.GetListProductsAsync(productl.ID);
    }


}