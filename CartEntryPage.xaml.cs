using Proiect_Telefon.Models;

namespace Proiect_Telefon;

public partial class CartEntryPage : ContentPage
{
	public CartEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetShopListsAsync();
    }
    async void OnShopListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CartPage
        {
            BindingContext = new ProductList()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new CartPage
            {
                BindingContext = e.SelectedItem as ProductList
            });
        }
    }
}