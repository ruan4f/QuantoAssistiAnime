using QuantoAssistiAnime.Model.Entidades;
using QuantoAssistiAnime.Model.Servicos;
using Xamarin.Forms;

namespace QuantoAssistiAnime.ViewModel
{
    public class DetalheAnimeViewModel : ObservableBaseObject
    {
        private Anime anime;

        public DetalheAnimeViewModel(Anime anime)
        {
            MessageService = DependencyService.Get<IMessageService>();
            NavigationService = DependencyService.Get<INavigationService>();

            ExcluirAnimeCommand = new Command(Excluir);
            AtualizarAnimeCommand = new Command(Atualizar);

            this.anime = anime;

            Nome = anime.Nome;
            EpisodioAtual = anime.EpisodioAtual;
            TotalEpisodios = anime.TotalEpisodios;
        }

        public Command ExcluirAnimeCommand { get; set; }
        public Command AtualizarAnimeCommand { get; set; }

        private string nome;

        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                anime.Nome = value;
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
                anime.EpisodioAtual = value;
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
                anime.TotalEpisodios = value;
                OnPropertyChanged();
            }
        }

        #region Métodos

        private async void Atualizar()
        {
            App.AzureClient.UpdateAnime(anime);

            await MessageService.ShowAsync("Dados atualizados com sucesso!");
        }

        private async void Excluir()
        {
            App.AzureClient.DeleteAnime(anime);

            await NavigationService.Voltar();
        }

        #endregion

    }
}
