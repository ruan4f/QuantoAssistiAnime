using QuantoAssistiAnime.Model;
using Xamarin.Forms;

namespace QuantoAssistiAnime.ViewModels
{
    public class DetalheAnimeViewModel : BaseViewModel
    {
        private Anime anime;

        public DetalheAnimeViewModel(Anime anime)
        {
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

            await DisplayAlert("Quanto Assisti Anime", "Dados atualizados com sucesso!", "OK");
        }

        private async void Excluir()
        {
            App.AzureClient.DeleteAnime(anime);

            await DisplayAlert("Quanto Assisti Anime", "Anime excluído com sucesso!", "OK");

            await PopAsync();
        }

        #endregion

    }
}
