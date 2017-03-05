using QuantoAssistiAnime.Model.Entidades;
using QuantoAssistiAnime.Model.Servicos;
using Xamarin.Forms;

namespace QuantoAssistiAnime.ViewModel
{
    public class NovoAnimeViewModel : ObservableBaseObject
    {
        public NovoAnimeViewModel( )
        {
            MessageService = DependencyService.Get<IMessageService>();
            NavigationService = DependencyService.Get<INavigationService>();

            AdicionarAnimeCommand = new Command(adicionarAnime);
        }

        public Command AdicionarAnimeCommand { get; set; }

        private string nome;

        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value; 
                OnPropertyChanged();
            }
        }

        private int episodioAtual;

        public int EpisodioAtual
        {
            get { return episodioAtual; }
            set
            {
                episodioAtual = value; 
                OnPropertyChanged();
            }
        }

        private int totalEpisodios;

        public int TotalEpisodios
        {
            get { return totalEpisodios; }
            set
            {
                totalEpisodios = value; 
                OnPropertyChanged();
            }
        }

        #region Métodos

        private async void adicionarAnime()
        {
            var anime = new Anime()
            {
                Nome = Nome,
                EpisodioAtual = EpisodioAtual,
                TotalEpisodios = TotalEpisodios
            };

            App.AzureClient.AddAnime(anime);

            await MessageService.ShowAsync("Anime adicionado com Sucesso!");

            await NavigationService.Voltar();
        }

        #endregion

    }
}
