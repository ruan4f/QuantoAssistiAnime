using QuantoAssistiAnime.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuantoAssistiAnime.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaAnimeView : ContentPage
    {
        private ListaAnimeViewModel ViewModel => BindingContext as ListaAnimeViewModel;

        public ListaAnimeView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel?.Load();
        }
        
        private void ListViewAnimes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ViewModel.DetalhaAnimeCommand.Execute(e.SelectedItem);
            }
        }
    }
}
