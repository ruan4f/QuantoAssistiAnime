using QuantoAssistiAnime.Model.Entidades;
using QuantoAssistiAnime.ViewModel;
using Xamarin.Forms;

namespace QuantoAssistiAnime.View
{
    public partial class DetalheAnimeView : ContentPage
    {
        public DetalheAnimeView(Anime anime)
        {
            InitializeComponent();
            BindingContext = new DetalheAnimeViewModel(anime);
        }
    }
}
