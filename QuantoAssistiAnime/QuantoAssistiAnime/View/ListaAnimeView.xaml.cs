using System;
using QuantoAssistiAnime.Model.Entidades;
using QuantoAssistiAnime.ViewModel;
using Xamarin.Forms;

namespace QuantoAssistiAnime.View
{
    public partial class ListaAnimeView : ContentPage
    {
        private readonly ListaAnimeViewModel _viewModel;

        public ListaAnimeView()
        {
            InitializeComponent();

            _viewModel = new ListaAnimeViewModel();

            ListViewAnimes.ItemSelected += ListViewAnimes_ItemSelected;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.Load();

            BindingContext = _viewModel;
        }

        private async void AdicionarAnime_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NovoAnimeView());
        }
        
        private async void ListViewAnimes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedAnime = e.SelectedItem as Anime;
            if (selectedAnime != null)
            {
                await Navigation.PushAsync(new DetalheAnimeView(selectedAnime));
                ListViewAnimes.SelectedItem = null;
            }
        }
    }
}
