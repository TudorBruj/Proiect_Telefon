namespace Proiect_Telefon
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        private void OnCosButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CartEntryPage());
        }
        private void OnAboutButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }
    }
}