using QuantoAssistiAnime.Model.Servicos;
using QuantoAssistiAnime.ViewModel;
using Xamarin.Forms;

namespace QuantoAssistiAnime.View
{
    public partial class NovoAnimeView : ContentPage
    {
        public NovoAnimeView()
        {
            InitializeComponent();
            BindingContext = new NovoAnimeViewModel();
        }
    }
}
