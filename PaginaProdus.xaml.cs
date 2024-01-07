using Proiect_Telefon.Models;
namespace Proiect_Telefon;

public partial class PaginaProdus : ContentPage
{
    ProductList p1;

    public PaginaProdus(ProductList plist)
    {
        InitializeComponent();
        p1 = plist;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var produs = (Produs)BindingContext;
        await App.Database.SaveProductAsync(produs);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var produs = (Produs)BindingContext;
        await App.Database.DeleteProductAsync(produs);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Produs p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Produs;
            var lp = new ListaProdus()  
            {
                ShopListID = p1.ID,
                ProductID = p.ID
            };
            await App.Database.SaveProductListAsync(lp);
            p.ListaProduse = new List<ListaProdus> { lp };
            await Navigation.PopAsync();
        }
    }
}
